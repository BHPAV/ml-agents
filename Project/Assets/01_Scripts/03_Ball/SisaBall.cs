using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;



public class SisaBall : MonoBehaviour
{
    /// <summary>
    /// The associated agent.
    /// This will be set by the agent script on Initialization.
    /// Don't need to manually set.
    /// </summary>

    public AgentCore lastTouched;


    ///COLLISIONS SECTION ----------------------------------------------------------------

    void OnCollisionEnter(Collision col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("goal"))
        {
            Debug.Log("Goal Touch");
            HitGoal(lastTouched);
        }

        if (col.gameObject.CompareTag("wall"))
        {
            HitWall();
        }

        if (col.gameObject.CompareTag("agent"))
        {
            AgentCore _agentCore = col.gameObject.GetComponent<AgentCore>();
            HitAgent(_agentCore);
            HitAgent();
        }
    }

    
    void OnTriggerEnter(Collider col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag("goal"))
        {
            HitGoal(lastTouched);
        }
    }
    


    ///EVENTS SECTION ----------------------------------------------------------------
    [Title("Events")]
    public GameEvent eventHitGoal;
    public GameEvent eventHitWall;
    public GameEvent eventHitAgent;

    public GameEvent eventFellOffLevel;
    
    

    void HitGoal(AgentCore _agent)
    {
        //_hitGoal?.Invoke();
        eventHitGoal?.Invoke(_agent);
    }

    void HitWall()
    {
        //eventHitWall.Invoke();
    }

    void HitAgent()
    {
        eventHitAgent?.Invoke();
    }

    void HitAgent(AgentCore _agent)
    {
        eventHitAgent.Invoke(_agent);
        lastTouched = _agent;
    }

    public void TestMessage()
    {
        Debug.Log("BALL TOUCHED");
    }

    public void TestMessage(AgentCore _agent)
    {
        Debug.Log("BALL TOUCHED BY " + _agent.gameObject.name);
    }

    public void UpdateLastTouched(AgentCore _agent)
    {
        Debug.Log("BALL TOUCHED BY " + _agent.gameObject.name);
    }
    
}
