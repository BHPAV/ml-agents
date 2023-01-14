using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidReset : MonoBehaviour
{
    public GameObject target;
    public float distanceUp = 15f;
    public bool reset = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            reset = true;

            
        }
    }

    private void FixedUpdate()
    {
        if (reset)
        {
            Vector3 newPosition = target.transform.position;
            newPosition.y = distanceUp;
            target.transform.position = newPosition;

            reset = false;
        }
    }
}
