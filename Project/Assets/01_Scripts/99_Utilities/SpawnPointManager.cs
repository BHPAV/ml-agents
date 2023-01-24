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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
