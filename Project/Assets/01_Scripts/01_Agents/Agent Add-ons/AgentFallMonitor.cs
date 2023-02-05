using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFallMonitor : MonoBehaviour
{

    public AgentEvent _agentFellOffLevel;
    private AgentCore agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentCore>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FallCheck();
    }


    private void FallCheck()
    {
        if(transform.localPosition.y <= -5.0f)
            _agentFellOffLevel?.Invoke(agent);
    }

}
