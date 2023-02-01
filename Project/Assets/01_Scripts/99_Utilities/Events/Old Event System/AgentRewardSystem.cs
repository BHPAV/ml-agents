using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRewardSystem : MonoBehaviour
{

    //Public
    public string rewardName;
    public AgentBus agentBus;
    public float rewardWeight;
    float rewardValue;


    //Speed Optimization
    [SerializeField] private bool EncourageSpeed;
    [SerializeField] private bool EncourageBallDistance;
    [SerializeField] private bool EncourageBallTouch;
    [SerializeField] private bool DiscourageCrashIntoWall;

    [SerializeField] private float ballToGoalDistance;
    [SerializeField] private float ballToGoalDistanceMin;
    [SerializeField] private float ballToGoalDistanceMax;

    [SerializeField] private float RewardTouches;
    [SerializeField] private float RewardTime;
    [SerializeField] private float RewardBallDistance;

    [SerializeField] private int MaxStep;
    [SerializeField] private int CurrentSteps;

    [SerializeField] private float weightCrash;
    [SerializeField] private float weightSpeed;
    [SerializeField] private float weightWall;
    [SerializeField] private float weightTouch;
    [SerializeField] private float weightGoal;


    //Collission Target
    [SerializeField] private bool GoToTarget;
    [SerializeField] private Transform Target;          //Potentially change this to a collider?



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetReward()
    {
        float _result = 0.0f;
        _result = rewardValue * rewardWeight;
        return _result;
    }

    public void RewardTheAgent(float _rewardValue)
    {
        if(_rewardValue >= 1.0f)
            Debug.Log("Reward of " + _rewardValue);
    }




    public void BallHitWall(AgentBus _agent)
    {
        if(_agent == agentBus && DiscourageCrashIntoWall)
        {
            PunishAndEnd(); 

            Debug.Log("Negative Crash Reward");
        }
            
    }

    private void AgentHitBall() 
    {
        if(EncourageBallTouch)
        {
            //Limit total number of rewards for Touching
            float _reward = 0.25f/4f;
            if(RewardTouches <= 0.25f)
            {
                agentBus.AddReward(_reward);
                RewardTouches += _reward;
            }
        }  
    }

    private float CrashReward()
    {
        return -1.0f;
    }

    private void PunishAndEnd() 
    {
        // code for punishing the crash goes here
        agentBus.AddReward(-1f);

        // By marking an agent as done AgentReset() will be called automatically.
        agentBus.EndEpisode();
    }


}
