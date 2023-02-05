using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Unity.MLAgents;




public class EvnController_Training_VsPushball : MonoBehaviour
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


    [SerializeField] private SisaBall ball;


    /// <summary>
    /// Max Academy steps before this platform resets
    /// </summary>
    /// <returns></returns>
    [Tooltip("Max Environment Steps")] public int MaxEnvironmentSteps = 25000;

    /// <summary>
    /// The area bounds.
    /// </summary>

    /// <summary>
    /// We will be changing the ground material based on success/failue
    /// </summary>


    //List of Agents On Platform
    public List<PlayerInfo> AgentsList = new List<PlayerInfo>();

    
    private SimpleMultiAgentGroup m_BlueAgentGroup;
    private SimpleMultiAgentGroup m_PurpleAgentGroup;

    private int m_ResetTimer;

    void Start()
    {
           
        // Initialize TeamManager
        m_BlueAgentGroup = new SimpleMultiAgentGroup();
        m_PurpleAgentGroup = new SimpleMultiAgentGroup();
        
        //Register Agents as part of their groups
        foreach (var item in AgentsList)
        {
            item.StartingPos = item.Agent.transform.position;
            item.StartingRot = item.Agent.transform.rotation;

            item.Rb = item.Agent.GetComponent<Rigidbody>();
            
            if (item.Agent.team == Team.Blue)
            {
                m_BlueAgentGroup.RegisterAgent(item.Agent);
            }
            else
            {
                m_PurpleAgentGroup.RegisterAgent(item.Agent);
            }
        }

        ResetScene();
    }

    void FixedUpdate()
    {
        m_ResetTimer += 1;
        if (m_ResetTimer >= MaxEnvironmentSteps && MaxEnvironmentSteps > 0)
        {
            m_BlueAgentGroup.GroupEpisodeInterrupted();
            m_PurpleAgentGroup.GroupEpisodeInterrupted();
            ResetScene();
        }
    }


    public void ResetBall()
    {
        SpawnPointManager ballSpawnManager = ball.gameObject.GetComponent<SpawnPointManager>();
        ballSpawnManager.MoveToRandomSpawnPosition();
    }

    public void GoalTouched(Team scoredTeam)
    {
        /*
        if (scoredTeam == Team.Blue)
        {
            m_BlueAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_PurpleAgentGroup.AddGroupReward(-1);
        }
        else
        {
            m_PurpleAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_BlueAgentGroup.AddGroupReward(-1);
        }
        m_PurpleAgentGroup.EndGroupEpisode();
        m_BlueAgentGroup.EndGroupEpisode();
        
        */

        ResetScene();
    }


    public void GoalTouched(AgentCore _agent)
    {
        if(AgentInList(_agent))
        {
            foreach (var item in AgentsList)
            {
                if (item.Agent == _agent)
                {
                    item.Agent.ApplyReward(1.0f);
                    GroupRewarder(item.Agent.team);
                }
                else
                {
                    item.Agent.ApplyReward(-1.0f);
                }   
            }

            EndGameEpisode();
            ResetScene();
        }
    }

    private void GroupRewarder(Team scoredTeam)
    {
        if (scoredTeam == Team.Blue)
        {
            m_BlueAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_PurpleAgentGroup.AddGroupReward(-1);
        }
        else
        {
            m_PurpleAgentGroup.AddGroupReward(1 - (float)m_ResetTimer / MaxEnvironmentSteps);
            m_BlueAgentGroup.AddGroupReward(-1);
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
                    item.Agent.ApplyReward(-0.25f);
                    SpawnPointManager spawnManager = item.Agent.gameObject.GetComponent<SpawnPointManager>();

                    var newStartPos = spawnManager.GetRandomSpawnPoint();
                    var newRot = Quaternion.Euler(0, 0, 0);
                    item.Agent.transform.SetPositionAndRotation(newStartPos, newRot);

                    item.Rb.velocity = Vector3.zero;
                    item.Rb.angularVelocity = Vector3.zero;
                }
                else
                {
                    item.Agent.ApplyReward(0.25f);
                }   
            }

            //EndGameEpisode();
            //ResetScene();
        }
    }

    public void BallTouched(AgentCore _agent)
    {
        if(AgentInList(_agent))
        {
            foreach (var item in AgentsList)
            {
                if (item.Agent == _agent)
                {
                    item.Agent.ApplyReward(0.005f);
                }
                else
                {
                    item.Agent.ApplyReward(-0.005f);
                }   
            }
        }
    }


    public void BallFell(AgentCore _agentLastTouched)
    {
        if(AgentInList(_agentLastTouched))
        {
            foreach (var item in AgentsList)
            {
                if (item.Agent == _agentLastTouched)
                {
                    item.Agent.ApplyReward(-1.0f);
                }
                else
                {
                    //item.Agent.ApplyReward(-0.001f);
                }   
            }

            EndGameEpisode();
            ResetScene();
        }
    }

    public void EndGameEpisode()
    {
        m_PurpleAgentGroup.EndGroupEpisode();
        m_BlueAgentGroup.EndGroupEpisode();
    }


    public void ResetScene()
    {
        m_ResetTimer = 0;
        
        //Reset Agents
        foreach (var item in AgentsList)
        {
            SpawnPointManager spawnManager = item.Agent.gameObject.GetComponent<SpawnPointManager>();

            var newStartPos = spawnManager.GetRandomSpawnPoint();
            var newRot = Quaternion.Euler(0, 0, 0);
            item.Agent.transform.SetPositionAndRotation(newStartPos, newRot);

            item.Rb.velocity = Vector3.zero;
            item.Rb.angularVelocity = Vector3.zero;
        }

        //Reset Ball
        ResetBall();
    }

    private void ResetAgent(AgentCore _agent)
    {

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
