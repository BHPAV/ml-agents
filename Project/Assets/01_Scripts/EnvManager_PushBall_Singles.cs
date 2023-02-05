using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager_PushBall_Singles : MonoBehaviour
{

    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject agentObj;

    [SerializeField] private AgentCore agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene(AgentCore _agent)
    {
        if(_agent == agent)
        {
            Reset(Ball);
            Reset(agentObj);
        }
    }


    private void Reset(GameObject _object)
    {
        SpawnPointManager _spm = _object.GetComponent<SpawnPointManager>();
        _spm.MoveToRandomSpawnPosition();
    }

}
