using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBus_GoalDetect : MonoBehaviour
{
    /// <summary>
    /// The associated agent.
    /// This will be set by the agent script on Initialization.
    /// Don't need to manually set.
    /// </summary>
    [HideInInspector]
    public AgentBus agent;  //

    void OnCollisionEnter(Collision col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("goal"))
        {
            HitGoal();
        }

        if (col.gameObject.CompareTag("wall"))
        {
            HitWall();
        }

        if (col.gameObject.CompareTag("agent"))
        {
            HitAgent();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("goal"))
        {
            HitGoal();
        }
    }


    [SerializeField] GameEvent _hitWall;
    [SerializeField] RewardEvent _hitWallReward;
    void HitWall()
    {
        //_hitWallReward.Invoke(agent);
        //_hitWall?.Invoke(agent);
    }

    [SerializeField] GameEvent _hitGoal;
    [SerializeField] RewardEvent _hitGoalReward;
    void HitGoal()
    {
        //_hitGoal?.Invoke();
        //_hitGoalReward.Invoke(agent);
    }

    [SerializeField] RewardEvent _hitBallReward;
    void HitAgent()
    {
        //_hitBallReward.Invoke(agent);
    }

    
}
