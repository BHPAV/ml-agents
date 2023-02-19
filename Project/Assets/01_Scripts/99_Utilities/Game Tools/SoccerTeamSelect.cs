using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SoccerTeamSelect : MonoBehaviour
{
    public List<GameObject> TeamOne;
    public List<GameObject> TeamTwo;

    public List<Actor> TeamOneActors = new List<Actor>();
    public List<Actor> TeamTwoActors = new List<Actor>();

    public GameObject Car, Van, Bus;

    private bool TeamOneSelected = false;
    private bool TeamTwoSelected = false;

    public GameObject ModelTest, SensorsTest, SensorsTest2;

    private SoccerGameManager soccerGameManager;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindSoccerGameManager(); 
    }

    private void FindSoccerGameManager()
    {
        soccerGameManager = FindObjectOfType<SoccerGameManager>();
        if (soccerGameManager == null)
        {
            //Debug.LogError("Could not find SoccerGameManager in the scene.");
        }
        else
        {
            TransferSelectiontoGameManager();
            JobDone();
        }
    }

    private void TransferSelectiontoGameManager()
    {
        soccerGameManager.AddTeamPrefabs(TeamOne, TeamTwo);
        soccerGameManager.AddTeamActors(TeamOneActors, TeamTwoActors);
    }

    private void JobDone()
    {
        Destroy(this);
    }

    private void AddToTeamOne(GameObject obj1)
    {
        if(!TeamOneSelected)
        {
            TeamOne.Add(obj1);
            TeamOne.Add(obj1);
            TeamOneSelected = true;

            Actor _act1 = new Actor(ModelTest, SensorsTest);
            TeamOneActors.Add(_act1);
            TeamOneActors.Add(_act1);
        }
    }

    private void AddToTeamTwo(GameObject obj1)
    {
        if(!TeamTwoSelected)
        {
            TeamTwo.Add(obj1);
            TeamTwo.Add(obj1);
            TeamTwoSelected = true;

            Actor _act1 = new Actor(ModelTest, SensorsTest2);
            TeamTwoActors.Add(_act1);
            TeamTwoActors.Add(_act1);
        }
    }

    public void SelectCar(int _team)
    {
        if(_team == 1)
        {
            AddToTeamOne(Car);
        }

        if(_team == 2)
        {
            AddToTeamTwo(Car);
        }
    }

    public void SelectVan(int _team)
    {
        if(_team == 1)
        {
            AddToTeamOne(Van);
        }

        if(_team == 2)
        {
            AddToTeamTwo(Van);
        }
    }

    public void SelectBus(int _team)
    {
        if(_team == 1)
        {
            AddToTeamOne(Bus);
        }

        if(_team == 2)
        {
            AddToTeamTwo(Bus);
        }
    }
}