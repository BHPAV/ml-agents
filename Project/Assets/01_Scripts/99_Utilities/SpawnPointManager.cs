using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{

    public List<Transform> transforms;

    public Transform GetRandomTransform()
    {
        int randomIndex = Random.Range(0, transforms.Count);
        return transforms[randomIndex];
    }

    public Vector3 GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, transforms.Count);
        return transforms[randomIndex].position;
    }


    public void MoveToRandomSpawnPosition()
    {
        if(transforms.Count > 0)
        {
            this.transform.position = GetRandomSpawnPoint();
        }
        else
        {
            Debug.Log("NO SPAWN POINTS TO MOVE TO FOR " + gameObject.name);
        }
        
    }

    public void MoveToRandomSpawnPosition(AgentCore _agent)
    {
        if(transforms.Count > 0)
        {
            this.transform.position = GetRandomSpawnPoint();
        }
        else
        {
            Debug.Log("NO SPAWN POINTS TO MOVE TO FOR " + gameObject.name);
        }
        
    }

}
