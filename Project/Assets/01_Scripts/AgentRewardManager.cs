using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;

public class AgentRewardManager : MonoBehaviour
{


    [SerializeField] private AgentCore agent;

    [SerializeField] private int StepCount;
    [SerializeField] private bool EncourageSpeed;



    //Controls total reward sent to agent
    void Start()
    {
        agent = transform.parent.GetComponent<AgentCore>();
    }

    void FixedUpdate()
    {
        RewardSpeed();
    }

    public void RewardAgent(AgentCore _agent)
    {
        Debug.Log(" Got This Far");

        if(_agent == agent)
        {
            Debug.Log(_agent.gameObject.name + " Agent Rewarded");
            agent.ApplyReward(1.0f);
        }
    }

    public void PunishAgent(AgentCore _agent)
    {
        if(_agent == agent)
        {
            agent.ApplyReward(-1.0f);
            Debug.Log(_agent.gameObject.name + " Agent Punished");
        }
    }


    public void RewardOrPunish(AgentCore _agent)
    {
        Debug.Log(" Got This Far");

        if(_agent == agent)
        {
            Debug.Log(_agent.gameObject.name + " Agent Rewarded");
            agent.ApplyReward(1.0f);
        }
        else
        {
            agent.ApplyReward(-1.0f);
            Debug.Log(_agent.gameObject.name + " Agent Punished");
        }
    }

    public void RewardSpeed()
    {
        if(agent != null & EncourageSpeed)
        {
            float _reward = -1.0f / agent.MaxStep;
            StepCount = agent.StepCount;
            agent.ApplyReward(_reward);
        }
            
    }

}
