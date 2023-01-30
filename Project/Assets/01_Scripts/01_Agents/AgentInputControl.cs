using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentInputControl : MonoBehaviour
{


    private AgentOverlord agent;
    
    public CarDriver carDriver;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<AgentOverlord>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inputs5(float forwardAmount, float turnAmount, float breakAction, float boostAction, float otherAction)  
    {
        carDriver.SetInputs5(forwardAmount, turnAmount, breakAction, boostAction, otherAction); 
    }
}
