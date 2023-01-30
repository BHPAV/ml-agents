//Put this script on your blue cube.

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class AgentBus : Agent
{

    
    public List<Transform> transforms;

    /// <summary>
    /// The ground. The bounds are used to spawn the elements.
    /// </summary>
    public GameObject ground;
    public GameObject area;

    public RewardEvent _actionReceived;
    public GameEvent _crashedEvent;
    public RewardEvent _EpisodeRestart;



    /// <summary>
    /// The area bounds.
    /// </summary>
    [HideInInspector]
    public Bounds areaBounds;

    PushBlockSettings m_PushBlockSettings;

    /// <summary>
    /// The goal to push the block to.
    /// </summary>
    public GameObject goal;
    public Goal_randomizeSize goalArea;

    /// <summary>
    /// The block to be pushed to the goal.
    /// </summary>
    public GameObject block;
    private bool isRound = true;

    

    public bool useVectorObs;

    public Rigidbody m_BlockRb;  //cached on initialization
    Rigidbody m_AgentRb;  //cached on initialization
    Material m_GroundMaterial; //cached on Awake()

    public CarDriver carDriver;

    /// <summary>
    /// We will be changing the ground material based on success/failue
    /// </summary>
    Renderer m_GroundRenderer;
    EnvironmentParameters m_ResetParams;

    public int stepsCheck = 0;




    //Reward Coding
    //[SerializeField] private AgentRewardManager rewardManager; private

    //private float RewardTouches;
    private float RewardTime;
    private float RewardBallDistance;
    private bool EncourageSpeed;
    private bool EncourageBallDistance;
    private bool EncourageBallTouch;
    private bool DiscourageBallCrash;
    private float ballToGoalDistance;
    private float ballToGoalDistanceMin;
    private float ballToGoalDistanceMax;


    [HideInInspector]
    public AgentBus_GoalDetect goalDetect;
    public SpawnPointManager spawnPointManager;



    


    /*
    //Specific Observations for Rotation of the Car
    [Observable(numStackedObservations: 9)]
    Vector2 Rotation
    {
        get
        {
            return new Vector2(gameObject.transform.rotation.z, gameObject.transform.rotation.x);
        }
    }

    [Observable(numStackedObservations: 9)]
    Vector3 WorldPosition
    {
        get
        {
            return gameObject.transform.position;
        }
    }

    //Specific Observations for Location of the Car - Speed Variable
    [Observable(numStackedObservations: 9)]
    Vector3 Position
    {
        get
        {
            return TargetPosition();
        }
    }

    //Specific Observations for Rotation of the Car
    [Observable(numStackedObservations: 9)]
    Vector3 Direction
    {
        get
        {
            return TargetDirection();
        }
    }
    */

    /*
    public Vector3 TargetPosition()
    {
        //Provides 1 Vector 3 observations.
        //If target is null - Provide zero value observations
        if(m_BlockRb != null)
            {
                // Target position in agent frame
                return this.transform.InverseTransformPoint(m_BlockRb.transform.position); // vec 3
            }
            else
            {
                return this.transform.InverseTransformPoint(transform.position); // vec 33
            }
    }

    public Vector3 TargetDirection()
    {
        //Provides 1 Vector 3 observations.
        //If target is null - Provide zero value observations
        Vector3 _result = Vector3.zero;

        if(m_BlockRb != null)
            {
                // Target Direction in agent frame
                _result = this.transform.InverseTransformDirection(m_BlockRb.transform.position);
                _result = _result.normalized;
                return _result;
            }
            else
            {
                return _result; // vec 3
            }
    }
    */

    

    protected override void Awake()
    {
        base.Awake();
        m_PushBlockSettings = FindObjectOfType<PushBlockSettings>(); 
    }

    public override void Initialize()
    {
        spawnPointManager = GetComponent<SpawnPointManager>();
        goalDetect = block.GetComponent<AgentBus_GoalDetect>();
        goalDetect.agent = this;

        // Cache the agent rigidbody
        m_AgentRb = GetComponent<Rigidbody>();
        // Cache the block rigidbody
        m_BlockRb = block.GetComponent<Rigidbody>();
        // Get the ground's bounds
        areaBounds = ground.GetComponent<Collider>().bounds;
        // Get the ground renderer so we can change the material when a goal is scored
        m_GroundRenderer = ground.GetComponent<Renderer>();
        // Starting material
        m_GroundMaterial = m_GroundRenderer.material;

        m_ResetParams = Academy.Instance.EnvironmentParameters;

        SetResetParameters();
    }

    

    /// <summary>
    /// Use the ground's bounds to pick a random spawn position.
    /// </summary>
    public Vector3 GetRandomSpawnPos()
    {
        /*
        var foundNewSpawnLocation = false;
        var randomSpawnPos = Vector3.zero;
        while (foundNewSpawnLocation == false)
        {
            var randomPosX = Random.Range(-areaBounds.extents.x * m_PushBlockSettings.spawnAreaMarginMultiplier,
                areaBounds.extents.x * m_PushBlockSettings.spawnAreaMarginMultiplier);

            var randomPosZ = Random.Range(-areaBounds.extents.z * m_PushBlockSettings.spawnAreaMarginMultiplier,
                areaBounds.extents.z * m_PushBlockSettings.spawnAreaMarginMultiplier);
            randomSpawnPos = ground.transform.position + new Vector3(randomPosX, 1f, randomPosZ);
            if (Physics.CheckBox(randomSpawnPos, new Vector3(2.5f, 0.01f, 2.5f)) == false)
            {
                foundNewSpawnLocation = true;
            }
        }
        */

        int randomIndex = Random.Range(0, transforms.Count);
        return transforms[randomIndex].position;

        //return randomSpawnPos;
    }




    /// <summary>
    /// Swap ground material, wait time seconds, then swap back to the regular material.
    /// </summary>
    IEnumerator GoalScoredSwapGroundMaterial(Material mat, float time)
    {
        m_GroundRenderer.material = mat;
        yield return new WaitForSeconds(time); // Wait for 2 sec
        m_GroundRenderer.material = m_GroundMaterial;
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

        // Launches event to let the reward system know to do it's thing.
        _actionReceived?.Invoke(this);


    /*
        if(EncourageSpeed)
        {
            float _reward = (-0.5f)/ MaxStep;
            AddReward(_reward);
            RewardTime += _reward;
        }

        if(EncourageBallDistance)
        {
            BallDistanceReward();
        }
    */

        //Check
        stepsCheck = stepsCheck + 1;
    }

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
    /// Resets the block position and velocities.
    /// </summary>
    void ResetBlock()
    {
        // Get a random position for the block.
        block.transform.position = spawnPointManager.GetRandomSpawnPoint();

        // Reset block velocity back to zero.
        m_BlockRb.velocity = Vector3.zero;

        // Reset block angularVelocity back to zero.
        m_BlockRb.angularVelocity = Vector3.zero;

    }

    /// <summary>
    /// In the editor, if "Reset On Done" is checked then AgentReset() will be
    /// called automatically anytime we mark done = true in an agent script.
    /// </summary>
    public override void OnEpisodeBegin()
    {
        
        
        var rotation = Random.Range(0, 4);
        var rotationAngle = rotation * 90f;
        area.transform.Rotate(new Vector3(0f, rotationAngle, 0f));

        ResetBlock();
        transform.position = GetRandomSpawnPos();
        m_AgentRb.velocity = Vector3.zero;
        m_AgentRb.angularVelocity = Vector3.zero;

        SetResetParameters();


        //CustomRewardCode ---------
        if(goalArea != null)
        {
            goalArea.ChangeScale();
        }

        stepsCheck = 0;
        ballToGoalDistanceMax = GetBalltoGoalDistance();
        ballToGoalDistanceMin = ballToGoalDistanceMax;

        ///RewardTouches = 0.0f;
        ///RewardTime = 0.0f;
        ///RewardBallDistance = 0.0f;

        //Let everyone know the episode is restarting.
        _EpisodeRestart?.Invoke(this);
    }

    public void SetGroundMaterialFriction()
    {
        var groundCollider = ground.GetComponent<Collider>();

        groundCollider.material.dynamicFriction = m_ResetParams.GetWithDefault("dynamic_friction", 0);
        groundCollider.material.staticFriction = m_ResetParams.GetWithDefault("static_friction", 0);
    }

    public void SetBlockProperties()
    {
        if(!isRound)
        {
            var scale = m_ResetParams.GetWithDefault("block_scale", 2);
            //Set the scale of the block
            m_BlockRb.transform.localScale = new Vector3(scale, 0.75f, scale);

            // Set the drag of the block
            m_BlockRb.drag = m_ResetParams.GetWithDefault("block_drag", 0.5f);
        }
    }

    void SetResetParameters()
    {
        SetGroundMaterialFriction();
        SetBlockProperties();
    }







    private void BallDistanceReward()
    {
        ballToGoalDistance = GetBalltoGoalDistance();
        if(ballToGoalDistance <= ballToGoalDistanceMin)
        {
            if(ballToGoalDistance <= ballToGoalDistanceMin)
                {
                    float _distTravelled = ballToGoalDistanceMin - ballToGoalDistance;
                    float _portionTravelled = _distTravelled / ballToGoalDistanceMax;

                    //Reward Calculation
                    float _reward = 0.5f * (_portionTravelled);
                    RewardBallDistance = RewardBallDistance + _reward;
                    AddReward(_reward);
                }
            

            ballToGoalDistanceMin = ballToGoalDistance;
        }
    }

    private float GetBalltoGoalDistance()
    {
        Vector3 _dist = (m_BlockRb.transform.position - goal.transform.position);
        float _result = _dist.magnitude;
        return _result;
    }




    //punish Crashing
    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "wall") 
        {
            PunishCrash();
        }

        if (collision.gameObject.tag == "ball") 
        {
            RewardBallTouch();
        }
    }



    private void PunishCrash() 
    {
        // code for punishing the crash goes here
        //AddReward(-1f);

        // By marking an agent as done AgentReset() will be called automatically.
        //EndEpisode();
    }

    public void PunishBallCrash() 
    {
        //if(DiscourageBallCrash)
        //{
            // code for punishing the crash goes here
        //    AddReward(-1f);

            // By marking an agent as done AgentReset() will be called automatically.
        //    EndEpisode();
        //}
        
    }

    private void RewardBallTouch() 
    {
        /*
        if(EncourageBallTouch)
        {
            //Limit total number of rewards for Touching
            float _reward = 0.25f/4f;
            if(RewardTouches <= 0.25f)
            {
                AddReward(_reward);
                RewardTouches += _reward;
            }
        } 
        */ 
    }

    public void ScoredAGoal()
    {
        // We use a reward of 5.
        //AddReward(1f);

        // By marking an agent as done AgentReset() will be called automatically.
        //EndEpisode();

        // Swap ground material for a bit to indicate we scored.
        StartCoroutine(GoalScoredSwapGroundMaterial(m_PushBlockSettings.goalScoredMaterial, 0.5f));
    }

    

    public void TestingMessage()
    {
        Debug.Log("IT WORKED");
    }


    public void ApplyReward(float _reward)
    {
        AddReward(_reward);
    }

    public void RequestEpisodeEnd()
    {
        EndEpisode();
    }


    public void ActionReceivedRewards() 
    {

    }

}
