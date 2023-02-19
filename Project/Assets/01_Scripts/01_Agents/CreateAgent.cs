using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAgent : MonoBehaviour
{
    public string agentName = "Agent Name";

    public GameObject agentModel;
    public GameObject agentSensorSuite;

    private GameObject model;

    void Start()
    {
        CreateTheAgent();
        NameAgent(agentName);
    }



    //Create Agent
    private void CreateTheAgent()
    {
        CreateAgentSubSystem _agent = new CreateAgentSubSystem(agentModel, agentSensorSuite);
        _agent.CreateTheAgent();

        model = _agent.GetModel();

        /*
        // Instantiate the first GameObject
        GameObject parentObject = Instantiate(agentModel, this.transform.position, Quaternion.identity);
        model = parentObject;

        // Instantiate the second GameObject as a child of the first
        GameObject childObject = Instantiate(agentSensorSuite, this.transform.position, Quaternion.identity);
        childObject.transform.SetParent(parentObject.transform);

        //Assign the Agent Core with the CarDriver control
        CarDriver _carDriver = parentObject.GetComponent<CarDriver>();
        AgentCore _agentCore = childObject.GetComponent<AgentCore>();
        _agentCore.SetCarDriver(_carDriver);


        //Assign the Agent Object to the same Parent as the Spawner
        model.transform.SetParent(transform.parent);
        */

    }


    //Change the Cloned Prefab Name
    private void NameAgent(string _name)
    {
        model.name = _name;
    }
}
