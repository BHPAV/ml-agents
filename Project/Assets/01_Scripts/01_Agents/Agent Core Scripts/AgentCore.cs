using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

using Sirenix.OdinInspector;

public class AgentCore : Agent
{

    [SerializeField] private bool Display;
    [SerializeField] private float CurrentReward;
    
    [SerializeField]
    [Title("Agent Control Items")] 
    private CarDriver carDriver;

    [Title("Agent Event Triggers")]
    public AgentEvent _actionReceived;
    public AgentEvent _EpisodeRestart;



    /// TESTING ONLY - NEEDS TO BE REMOVED
    public Team team;



    ////CORE AGENT ITEMS ---------------------------------------------------------- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    protected override void Awake()
    {
        //This controls the Agent Academy - Turns off if TRUE!!!
        if(Display)
            CommunicatorFactory.Enabled = false;

        base.Awake(); 
    }


    public override void Initialize()
    {

    }

    public void FixedUpdate()
    {
        CurrentReward = GetCumulativeReward();
    }


    /// <summary>
    /// Called every step of the engine. Here the agent takes an action.
    /// </summary>
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Move the agent using the action.
        ActionManagement(actionBuffers.DiscreteActions);

        // Launches event to let the reward system know to do it's thing.   --- EVENT SYSTEM
        _actionReceived?.Invoke(this);
    }


    /// <summary>
    /// Used to allow the player to use inputs to control the agent..
    /// </summary>
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        int forwardAction = 0;
        if (Input.GetKey(KeyCode.UpArrow)) forwardAction = 1;
        if (Input.GetKey(KeyCode.DownArrow)) forwardAction = 2;

        int turnAction = 0;
        if (Input.GetKey(KeyCode.RightArrow)) turnAction = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) turnAction = 2;

        int breakAction = 0;
        if (Input.GetKey(KeyCode.Space)) breakAction = 1;

        int boostAction = 0;
        if (Input.GetKey(KeyCode.LeftShift)) boostAction = 1;

        int generalAction = 0;
        if (Input.GetKey(KeyCode.F)) generalAction = 1;

        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = forwardAction;
        discreteActions[1] = turnAction;
        discreteActions[2] = breakAction;
        discreteActions[3] = boostAction;
        discreteActions[4] = generalAction;

    }




    /// <summary>
    /// In the editor, if "Reset On Done" is checked then AgentReset() will be
    /// called automatically anytime we mark done = true in an agent script.
    /// </summary>
    public override void OnEpisodeBegin()
    {
        //Let everyone know the episode is restarting.
        _EpisodeRestart?.Invoke(this);
    }



    //Public function that allows external scripts to call to apply a reward.
    public void ApplyReward(float _reward)
    {
        AddReward(_reward);
    }

    ////// --x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x--x\\\\ LEVI ITEMS

    /// <summary>
    /// Moves the agent according to the selected action.
    /// </summary>
    private void ActionManagement(ActionSegment<int> act)
    {
        if(carDriver != null)
            CarActions(act); 
    }

    /// <summary>
    /// Control Input specifially for Car Agents.
    /// </summary>
    private void CarActions(ActionSegment<int> act)
    {
        //// CAR WORKINGS ---------------
        float forwardAmount = 0f;
        float turnAmount = 0f;
        float breakAction = 0f;
        float boostAction = 0f;
        float otherAction = 0f;


        switch (act[0])
        {
            case 0: forwardAmount = 0f; break;
            case 1: forwardAmount = +1f; break;
            case 2: forwardAmount = -1f; break;
        }

        switch (act[1])
        {
            case 0: turnAmount = 0f; break;
            case 1: turnAmount = +1f; break;
            case 2: turnAmount = -1f; break;
        }

        switch (act[2])
        {
            case 0: breakAction = 0f; break;
            case 1: breakAction = +1f; break;
        }

        switch (act[3])
        {
            case 0: boostAction = 0f; break;
            case 1: boostAction = +1f; break;
        }

        switch (act[4])
        {
            case 0: otherAction = 0f; break;
            case 1: otherAction = +1f; break;
        }

        carDriver.ReceiveInput(forwardAmount, turnAmount, breakAction, boostAction, otherAction);
        ///// END CAR WORKINGS --------------  
    }


    public void SetCarDriver(CarDriver _carDriver)
    {
        carDriver = _carDriver;
    }
}
