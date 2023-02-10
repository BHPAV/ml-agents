using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Unity.MLAgents;




public class EvnController_Training_Sumov2 : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInfo
    {
        public AgentCore Agent;
        [HideInInspector]
        public Vector3 StartingPos;
        [HideInInspector]
        public Quaternion StartingRot;
        [HideInInspector]
        public Rigidbody Rb;
    }


    /// <summary>
    /// Max Academy steps before this platform resets
    /// </summary>
    /// <returns></returns>
    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps = 25000;


    //List of Agents On Platform
    public List<PlayerInfo> AgentsList = new List<PlayerInfo>();

    private int m_ResetTimer;

    void Start()
    {        
        //Register Agents as part of their groups
        foreach (var item in AgentsList)
        {
            item.StartingPos = item.Agent.transform.position;
            item.StartingRot = item.Agent.transform.rotation;

            item.Rb = item.Agent.GetComponent<Rigidbody>();
        }

        ResetScene();
    }

    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            ResetScene();
        }
    }


    public void AgentFell(AgentCore _agent)
    {
        if(AgentInList(_agent))
        {
            foreach (var item in AgentsList)
            {
                if (item.Agent == _agent)
                {
                    item.Agent.ApplyReward(-1.0f);
                }
                else
                {
                    item.Agent.ApplyReward(1.0f);
                }

                item.Agent.EndEpisode();   
            }

            ResetScene();
        }
    }


    public void EndGameEpisode()
    {
    }


    public void ResetScene()
    {
        m_ResetTimer = 0;
        
        //Reset Agents
        foreach (var item in AgentsList)
        {
            var newStartPos = item.StartingPos;
            var newRot = item.StartingRot;
            item.Agent.transform.SetPositionAndRotation(newStartPos, newRot);

            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
        }
    }

    private bool AgentInList(AgentCore _agent)
    {
        foreach (var item in AgentsList)
        {
            if (item.Agent == _agent)
            {
                return true;
            }
        }

        return false;
    }
}
