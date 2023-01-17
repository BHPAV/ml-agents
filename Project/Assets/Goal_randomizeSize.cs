using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_randomizeSize : MonoBehaviour
{

    public float min, max;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale()
    {
        // Generate a random float between 0.5f and 2.2f
        float scale = Random.Range(min, max);

        // Change the scale of the object
        transform.localScale = new Vector3(scale, 1.0f, scale);
    }
}
