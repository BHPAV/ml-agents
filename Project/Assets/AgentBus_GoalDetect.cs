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
            agent.ScoredAGoal();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("goal"))
        {
            agent.ScoredAGoal();
        }
    }
}
