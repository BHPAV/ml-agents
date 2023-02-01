using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDistanceReward : MonoBehaviour
{

    public AgentCore agent;
    public GameObject object1;
    public GameObject object2;
    public float maxDistance;
    public float previousBestDistance;
    public float distancePrevious;
    public float distance;

    public float distanceNormalized;

    
    void Start()
    {
        GetDistance();
    }

    void Update()
    {
        GetDistance();
    }


    private void GetDistance()
    {
        distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        distanceNormalized = GetNormalizedDistance();
    }


    public void ResetMaxDistance(AgentCore _agent)
    {
        if(_agent == agent)
        {
            GetDistance();
            maxDistance = distance;
            previousBestDistance = maxDistance;
        }
            
    }

    public float GetNormalizedDistance()
    {
        float distance = Vector3.Distance(object1.transform.position, object2.transform.position);
        return distance / maxDistance;
    }



    public void RewardAgent(AgentCore _agent)
    {
        //if(_agent == agent)
            //agent.ApplyReward(GetNormalizedDistance());
    }


    public void DistanceCheck(AgentCore _agent)
    {
        if(_agent == agent)
        {
            if (distance < previousBestDistance)
            {
                float _change = previousBestDistance - distance;
                float _reward = _change / maxDistance;
                agent.ApplyReward(_reward);
                
                previousBestDistance = distance;
            }
            else
            {
                float _change = distance - previousBestDistance;
                float _reward = _change / maxDistance;
                agent.ApplyReward(_reward);                
            }
        }
            
    }

    public void RewardV2(AgentCore _agent)
    {
        if(_agent == agent)
        {
            float _change = distancePrevious - distance;
            float _reward = _change / maxDistance;
            agent.ApplyReward(_reward);
            
            distancePrevious = distance;    
        }    
    }
}
