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

    private SpawnPointManager spawnPointManager;

    public AgentCore myAgent;
    public AgentCore lastTouched;


    void Start()
    {
        spawnPointManager = GetComponent<SpawnPointManager>();
    }


    void Update()
    {
        if(transform.localPosition.y <= -5.0f)
        {
            FellOffLevel(myAgent);
        }     
    }


    public void ResetBall(AgentCore _agent)
    {
        if(_agent == myAgent)
        {
            spawnPointManager.MoveToRandomSpawnPosition();
        }
    }


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
    
    public GameEvent eventHitWall;
    
    
    public AgentEvent eventHitAgent;


    
    


    //Fall off Level Event
    public AgentEvent agentEventFellOffLevel;
    private void FellOffLevel(AgentCore _agent)
    {
        agentEventFellOffLevel?.Invoke(_agent);
    }
    
    public AgentEvent agentScoredGoal;
    void HitGoal(AgentCore _agent)
    {
        agentScoredGoal?.Invoke(_agent);
    }

    void HitWall()
    {
        //eventHitWall.Invoke();
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
