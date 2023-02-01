using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentReward : MonoBehaviour
{
    
    [SerializeField] private AgentBus agent;
    [SerializeField] private string rewardName;
    [SerializeField] private float rewardWeight;
    [SerializeField] private float rewardValue;

    [SerializeField] private float currentValueTouchReward;
    
    [SerializeField] private bool isPositive;
    [SerializeField] private bool isGameEnding;
    [SerializeField] private bool isConfirmed;

    [SerializeField] AgentEvent _agentEvent;
    

    [SerializeField] private float rewardCrashWall;

    [SerializeField] private float rewardGoal;
    [SerializeField] private bool limitGoalTouch;
    [SerializeField] private float countGoal;
    [SerializeField] private float maxGoal;

    
    [SerializeField] private bool limitBallTouch;
    [SerializeField] private float rewardBallTouch;
    [SerializeField] private float countBallTouch;
    [SerializeField] private float maxBallTouch;

    [SerializeField] private GameObject _BallObj;
    [SerializeField] private GameObject _AgentObj;

    




    public void GetDistance(GameObject _object1, GameObject _object2)
    {
        float distance = Vector3.Distance(_object1.transform.position, _object2.transform.position);
        Debug.Log(distance);
    }



    
    
        
    public void ResetStats(AgentBus _agent)
    {
        if(_agent == agent)
        {
            countBallTouch = 0;
            countGoal = 0;
        }
    }

    public void IssueReward(AgentBus _agent)
    {
        if(_agent == agent)
        {
            agent.ApplyReward(CalculateReward());

            if(isGameEnding)
                agent.RequestEpisodeEnd();
            
            if(isConfirmed)
                Debug.Log(rewardName);
        }
    }

    //Math to return the reward value
    private float CalculateReward()
    {
        float _result = rewardValue * rewardWeight;
        return _result;
    }

    private bool AgentCheck(AgentBus _agent)
    {
        return (_agent == agent);    
    }

    public void PunishBallCrash(AgentBus _agent) 
    {

        if(AgentCheck(_agent))
        {
            // code for punishing the crash goes here
            agent.ApplyReward(-1f);
            agent.RequestEpisodeEnd();
        } 
    }

    public void DiscourageBallCrash(AgentBus _agent) 
    {
        if(AgentCheck(_agent))
        {
            // code for punishing the crash goes here
            agent.ApplyReward(-0.0002f);
        }
    }

    public void PunishCrash(AgentBus _agent) 
    {
        if(AgentCheck(_agent))
        {
            // code for punishing the crash goes here
            agent.ApplyReward(-1f);
            agent.RequestEpisodeEnd();
        }
    }





    

    public void DiscourageCrash(AgentBus _agent) 
    {
        if(AgentCheck(_agent))
        {
            // code for punishing the crash goes here
            agent.ApplyReward(rewardCrashWall);
            agent.RequestEpisodeEnd();
        }
    }




    public void ScoredAGoal(AgentBus _agent)
    {
        if(AgentCheck(_agent))
        {
            if(!limitGoalTouch || countGoal >= maxGoal)
            {
                agent.ScoredAGoal();
                agent.ApplyReward(1f);
                agent.RequestEpisodeEnd();
            }
            else    
                countBallTouch = countBallTouch + 1;
            
        }
    }

    public void RewardBallTouch(AgentBus _agent) 
    {
        if(AgentCheck(_agent))
        {
            float _reward = rewardBallTouch;                
            agent.ApplyReward(_reward);

            if(!limitBallTouch || countBallTouch >= maxBallTouch)
                agent.RequestEpisodeEnd();
            else    
                countBallTouch = countBallTouch + 1;
        }
    }

    public void RewardDistanceBall(AgentBus _agent)
    {
        //Divide this by 20...
        float _result = 0.0f;

        float _balldistance = GetDistance();
        _result = 1.0f - _balldistance / 20.0f;

        agent.ApplyReward(_result);
    }

    public float GetDistance()
    {
        return Vector3.Distance(_BallObj.transform.position, _AgentObj.transform.position);
    }


}
