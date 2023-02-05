using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{

    public AgentCore agent;
    public SpawnPointManager ballSpawnPointManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentCore>();
    }

    public void RespawnBall(AgentCore _agent)
    {
        if(agent == _agent)
            ballSpawnPointManager.MoveToRandomSpawnPosition();
    }

}
