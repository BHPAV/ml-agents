using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public string agentName = "Actor Name";

    public GameObject agentModel;
    public GameObject agentSensorSuite;

    private GameObject model;

    public Actor(GameObject _agentModel, GameObject _agentSensorSuite)
    {
        agentModel = _agentModel;
        agentSensorSuite = _agentSensorSuite;
    }

    public void CreateActor()
    {
        // Instantiate the first GameObject
        GameObject parentObject = Object.Instantiate(agentModel, Vector3.zero, Quaternion.identity);
        model = parentObject;

        // Instantiate the second GameObject as a child of the first
        GameObject childObject = Object.Instantiate(agentSensorSuite, Vector3.zero, Quaternion.identity);
        childObject.transform.SetParent(parentObject.transform);

        //Assign the Agent Core with the CarDriver control
        CarDriver _carDriver = parentObject.GetComponent<CarDriver>();
        AgentCore _agentCore = childObject.GetComponent<AgentCore>();
        _agentCore.SetCarDriver(_carDriver);


        //Assign the Agent Object to the same Parent as the Spawner
        //model.transform.SetParent(GameObject.Find("Agents").transform);
    }


    public GameObject GetModel()
    {
        return model;
    }


    public void NameActor(string _name)
    {
        model.name = _name;
    }
}