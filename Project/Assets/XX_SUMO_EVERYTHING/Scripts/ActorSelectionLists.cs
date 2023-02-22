using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSelectionLists : MonoBehaviour
{

    public GameObject testModel;
    public GameObject testSensorSet;

    public GameObject dummyModel;
    public GameObject dummySensorSet;

    public List<Actor> team1Actors = new List<Actor>(); // a list of gameobject prefabs for team 1
    public List<Actor> team2Actors = new List<Actor>(); // a list of gameobject prefabs for team 2

    public GameObject defaultModel;
    public GameObject defaultSensorSet;

    public bool Testing = false;

    // Start is called before the first frame update
    void Start()
    {
        TestStartMode();
        DefaultStartMode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public List<Actor> GetTeamActors(int _team)
    {
        List<Actor> _result = team1Actors;

        switch(_team)
        {
            case 1 : { _result = team1Actors; } break;
            case 2 : { _result = team2Actors; } break;
        }

        return _result;
    }


    public void CreateNewActor(int _team, GameObject _Model, GameObject _SensorSet)
    {
        Actor actor = new Actor(_Model, _SensorSet);

        switch(_team)
        {
            case 1: {team1Actors.Add(actor);} break;
            case 2: {team2Actors.Add(actor);} break;
        }
    }

    public void DefaultStartMode()
    {
        //Load Default Models if a Selection hasn't been made
        /// Team 1
        if(team1Actors.Count < 1)
        {
            CreateNewActor(1,defaultModel,defaultSensorSet);
        }

        /// Team 2
        if(team2Actors.Count < 1)
        {
            CreateNewActor(2,defaultModel,defaultSensorSet);
        }
    }


    public void TestStartMode()
    {
        if(Testing)
        {
            //Load Default Models if a Selection hasn't been made
            /// Team 1
            CreateNewActor(1,testModel,testSensorSet);


            /// Team 2
            CreateNewActor(2,dummyModel,dummySensorSet);
        }
    }
}
