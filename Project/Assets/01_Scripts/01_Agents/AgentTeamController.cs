using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;



public class AgentTeamController : MonoBehaviour
{

    ///This component is required if the Agent is working as part of a team.

    public BehaviorParameters m_BehaviorParameters;
    public Team team;
    //public Position position;

    public float groupReward = 0f;
    public float groupPunish = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void AssignTeam()
    {
        m_BehaviorParameters = gameObject.GetComponent<BehaviorParameters>();
        if (m_BehaviorParameters.TeamId == (int)Team.Blue)
        {
            team = Team.Blue;
            //initialPos = new Vector3(transform.position.x - 5f, .5f, transform.position.z);
            //rotSign = 1f;
        }
        else
        {
            team = Team.Purple;
            //initialPos = new Vector3(transform.position.x + 5f, .5f, transform.position.z);
            //rotSign = -1f;
        }
    }

    private void AssignPosition()
    {
        /*
        if (position == Position.Goalie)
        {
            m_LateralSpeed = 1.0f;
            m_ForwardSpeed = 1.0f;
        }
        else if (position == Position.Striker)
        {
            m_LateralSpeed = 0.3f;
            m_ForwardSpeed = 1.3f;
        }
        else
        {
            m_LateralSpeed = 0.3f;
            m_ForwardSpeed = 1.0f;
        }
        */
    }

}
