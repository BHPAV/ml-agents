using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetectTrigger : MonoBehaviour
{

    [SerializeField] private AgentBus agent;
    [SerializeField] private string tagCompare; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag(tagCompare))
        {
            agent.ScoredAGoal();
        }

        if (col.gameObject.CompareTag(tagCompare))
        {
            agent.PunishBallCrash();
            HitWall();
        }
    }

    [SerializeField] CustomUnityEvent<AgentBus> AgentEvent = EventManagementSystem.CreateEvent<AgentBus>();
    void HitWall()
    {
        AgentEvent?.Invoke(agent);
    }





}
