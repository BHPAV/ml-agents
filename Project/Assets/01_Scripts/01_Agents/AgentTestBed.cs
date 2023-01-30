
using System.Collections;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;



public class AgentTestBed : Agent
{


    //Rigidbody m_AgentRb;  //cached on initialization
    [SerializeField] CarData carData;


    //Control Variables
    private CarDriver carDriver;
    private GameObject car;

    private Rigidbody m_AgentRb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed!");
        }
    }


    private void CreateModel()
    {
        //Create the model for the Agent to play with
        car = Instantiate(carData.carPrefab,transform);
        //car.transform.parent = transform;

    /*
        //Connect the driving part to the Agent
        carDriver = car.GetComponent<CarDriver>();

        

        //Transfer the physical properties of the model
        // Get the child gameobject's collider
        Collider childCollider = car.GetComponent<BoxCollider>();

        // Get the child gameobject's rigidbody
        Rigidbody childRigidbody = car.GetComponent<Rigidbody>();

        // Check if child has both collider and rigidbody
        if (childCollider != null && childRigidbody != null)
        {
            // Copy the properties of the child's collider and rigidbody
            BoxCollider parentCollider = gameObject.GetComponent<BoxCollider>();
            parentCollider.enabled = false;
            //parentCollider.isTrigger = childCollider.isTrigger;
            //parentCollider.material = childCollider.material;
            //parentCollider.size = ((BoxCollider)childCollider).size;
            //parentCollider.size = new Vector3(0.3f,0.555f,1.510f);
            
            //parentCollider.center = ((BoxCollider)childCollider).center;
            //parentCollider.center = new Vector3(-0.3f,0.4423108f,0.0f);

            m_AgentRb = gameObject.AddComponent<Rigidbody>();
            m_AgentRb.mass = childRigidbody.mass;
            m_AgentRb.drag = childRigidbody.drag;
            m_AgentRb.angularDrag = childRigidbody.angularDrag;
            m_AgentRb.useGravity = childRigidbody.useGravity;

            //Update the driver control rigidbody objects
            carDriver.Car_Rigidbody = m_AgentRb; 

            // Remove the collider and rigidbody from the child gameobject
            //Destroy(childCollider);
            Destroy(childRigidbody);
        
        }
    */    
        
    }

    private void TransferColliders()
    {
        
    }


    protected override void Awake()
    {
        base.Awake(); 
    }


    public override void Initialize()
    {
        // Cache the agent rigidbody
        //m_AgentRb = GetComponent<Rigidbody>();

        //Create the Agent Model
        CreateModel();
    }

    /// <summary>
    /// Moves the agent according to the selected action.
    /// </summary>
    public void MoveAgent(ActionSegment<int> act)
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

        carDriver.SetInputs5(forwardAmount, turnAmount, breakAction, boostAction, otherAction);
        ///// END CAR WORKINGS --------------  
    }


    /// <summary>
    /// Called every step of the engine. Here the agent takes an action.
    /// </summary>
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Move the agent using the action.
        MoveAgent(actionBuffers.DiscreteActions);

        // Launches event to let the reward system know to do it's thing.   --- EVENT SYSTEM
        //_actionReceived?.Invoke(this);
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
        //_EpisodeRestart?.Invoke(this);
    }



    //Public function that allows external scripts to call to apply a reward.
    public void ApplyReward(float _reward)
    {
        AddReward(_reward);
    }



}
