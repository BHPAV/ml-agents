using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class AgentRewardManager : MonoBehaviour
{
    /*
    //Controls total reward sent to agent
    private int rewardTotal;

    //Speed Optimization
    [SerializeField] private bool EncourageSpeed;
    [SerializeField] private int MaxStep;
    [SerializeField] private int CurrentSteps;

    [SerializeField] private float weightSpeed = 0.0f;
    [SerializeField] private float weightCrash = 0.0f;
    [SerializeField] private float weightTouch = 0.0f;
    [SerializeField] private float weightGoal = 0.0f;


    //Collission Target
    [SerializeField] private bool GoToTarget;
    [SerializeField] private Transform Target;          //Potentially change this to a collider?

    //List of things to Touch
    //List of things to Avoid
    //List of Allies?


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Increment Step Counter
        //CurrentSteps++;
    }

    //// PUBLIC FUNCTIONS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    public float GetAgentReward()
    {
        float _reward = 0.0f;

        //This is the part where we calculate all the reward vectores UwU....
        if(EncourageSpeed)
        {
            _reward += SpeedReward(weightSpeed);
            _reward += SpeedReward(weightCrash);
            _reward += SpeedReward(weightTouch);
            _reward += SpeedReward(weightGoal);
        }


        _reward = 1.0f;
        return _reward;
    }



    private float SpeedReward(float _weight)
    {
        //Add Weighting?
        //float _reward = (CurrentSteps / MaxStep) * _weight;
        float _reward = 1.0f;
        return _reward;
    }

    private float TargetReward(float _weight)
    {
        //float _reward = (_weight * 1.0f);
        float _reward = 1.0f;
        return _reward;
    }

    private float TouchReward(float _weight)
    {
        float _reward = (weightTouch * 1.0f) / MaxStep;
        return _reward;
    }



    void OnCollisionEnter(Collision other)
    {
        if(GoToTarget)
        {
            //Hit the thing I waant to hit
            if(other.gameObject == Target.gameObject)
            {
                //Reward on hit!

            }
        }
    }


    public void SmallReward()
    {
        AddReward(TouchReward);
    }
    */
}
