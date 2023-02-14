using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRewarder : MonoBehaviour
{


    public AgentCore agent;
    [SerializeField] private float kickForce = 2000f;
    [SerializeField] private float reward = 0.1f;
    [SerializeField] private bool training = false;


    // Start is called before the first frame update
    void Start()
    {
        AgentCore[] agentCores = GetComponentsInChildren<AgentCore>();
        agent = agentCores[0];
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("ball"))
        {
            // Kick The Ball
            var dir = c.contacts[0].point - transform.localPosition;
            dir = dir.normalized;
            c.gameObject.GetComponent<Rigidbody>().AddForce(dir * kickForce);

            // Reward The Agent
            if(training)
                agent.AddReward(reward);
        }
    }



}
