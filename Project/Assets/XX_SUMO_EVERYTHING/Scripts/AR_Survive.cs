using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Survive : MonoBehaviour
{
    [SerializeField] private float rewardMax;

    private AgentCore agentCore;

    private float agentMaxSteps;
    private float reward;

    private void Start()
    {
        agentCore = GetComponentInParent<AgentCore>();
        if (agentCore == null)
        {
            Debug.LogError("AgentCore component not found in parent GameObject!");
        }
        else
        {
            agentMaxSteps = agentCore.MaxStep;

            reward = rewardMax / agentMaxSteps;
        }
    }



    public void ApplyReward()
    {
        agentCore.AddReward(reward);
    }



}
