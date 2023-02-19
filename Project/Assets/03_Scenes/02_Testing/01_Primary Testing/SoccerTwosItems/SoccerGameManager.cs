
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using TMPro;

public class SoccerGameManager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> team1Prefabs; // a list of gameobject prefabs for team 1
    [HideInInspector] public List<GameObject> team2Prefabs; // a list of gameobject prefabs for team 2

    public List<Actor> team1Actors = new List<Actor>(); // a list of gameobject prefabs for team 1
    public List<Actor> team2Actors = new List<Actor>(); // a list of gameobject prefabs for team 2

    public GameObject ball; // a reference to the ball gameobject

    public List<Transform> Team1SpawnPoints; // a list of spawn points for team 1
    public List<Transform> Team2SpawnPoints; // a list of spawn points for team 2

    public List<GameObject> team1GameObjects = new List<GameObject>();
    public List<GameObject> team2GameObjects = new List<GameObject>();

    public List<Actor> team1GameActors = new List<Actor>();
    public List<Actor> team2GameActors = new List<Actor>();

    private Vector3 ballStartPosition;

    private CharacterSelectDropdownManager dropdownManager;

    private int scoreTeam1 = 0;
    private int scoreTeam2 = 0;

    [SerializeField] private TextMeshProUGUI TMP_Score1;
    [SerializeField] private TextMeshProUGUI TMP_Score2;

    [SerializeField] private TextMeshProUGUI TMP_BlueWin;
    [SerializeField] private TextMeshProUGUI TMP_PurpleWin;

    private bool canScore = true;


    private void Start()
    {
        GetDropDownManager();
        ActivateActorsData();

        //SpawnTeams();
        
        SpawnActors();

        ballStartPosition = ball.transform.position;
    }

    public void SpawnTeams()
    {
        // Spawn team 1 gameobjects
        for (int i = 0; i < team1Prefabs.Count; i++)
        {
            GameObject obj = Instantiate(team1Prefabs[i], Team1SpawnPoints[i].position, Team1SpawnPoints[i].rotation);
            obj.name = "Team 1 Player " + (i + 1);
            team1GameObjects.Add(obj);
        }

        // Spawn team 2 gameobjects
        for (int i = 0; i < team2Prefabs.Count; i++)
        {
            GameObject obj = Instantiate(team2Prefabs[i], Team2SpawnPoints[i].position, Team2SpawnPoints[i].rotation);
            obj.name = "Team 2 Player " + (i + 1);
            team2GameObjects.Add(obj);
        }
    }

    public void SpawnActors()
    {
        // Spawn team 1 gameobjects
        for (int i = 0; i < team1Actors.Count; i++)
        {
            team1Actors[i].CreateActor();
            
            GameObject obj = team1Actors[i].GetModel();
            obj.name = "Team 1 Player " + (i + 1);
            
            //obj.transform.position = Team1SpawnPoints[i].position;
            //obj.transform.rotation = Team1SpawnPoints[i].rotation;
            
            team1GameObjects.Add(obj);
        }

        // Spawn team 2 gameobjects
        for (int i = 0; i < team2Actors.Count; i++)
        {
            team2Actors[i].CreateActor();

            GameObject obj = team2Actors[i].GetModel();
            obj.name = "Team 2 Player " + (i + 1);
            
            //obj.transform.position = Team2SpawnPoints[i].position;
            //obj.transform.rotation = Team2SpawnPoints[i].rotation;
            
            team2GameObjects.Add(obj);
        }

        ResetPlayers();
    }

    

    public void AddTeamPrefabs(List<GameObject> newTeam1Prefabs, List<GameObject> newTeam2Prefabs)
    {
        team1Prefabs.AddRange(newTeam1Prefabs);
        team2Prefabs.AddRange(newTeam2Prefabs);
    }

    public void AddTeamActors(List<Actor> newTeam1Actors, List<Actor> newTeam2Actors)
    {
        team1Actors.AddRange(newTeam1Actors);
        team2Actors.AddRange(newTeam2Actors);
    }

    public void ResetPlayers()
    {
        // Move team 1 gameobjects back to spawn points
        for (int i = 0; i < team1GameObjects.Count; i++)
        {
            team1GameObjects[i].transform.position = Team1SpawnPoints[i].position;
            team1GameObjects[i].transform.rotation = Team1SpawnPoints[i].rotation;
            team1GameObjects[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        // Move team 2 gameobjects back to spawn points
        for (int i = 0; i < team2GameObjects.Count; i++)
        {
            team2GameObjects[i].transform.position = Team2SpawnPoints[i].position;
            team2GameObjects[i].transform.rotation = Team2SpawnPoints[i].rotation;
            team2GameObjects[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void StartGame()
    {
        // Unfreeze team 1 gameobjects
        for (int i = 0; i < team1GameObjects.Count; i++)
        {
            team1GameObjects[i].GetComponent<Rigidbody>().isKinematic = false;
        }

        // Unfreeze team 2 gameobjects
        for (int i = 0; i < team2GameObjects.Count; i++)
        {
            team2GameObjects[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void ResetBall()
    {
        ball.transform.position = ballStartPosition;
    }


    public void BounceBall(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 force = Vector3.up * 1000f;
            rb.AddForce(force);
        }
        else
        {
            Debug.LogWarning("The specified GameObject does not have a Rigidbody component.");
        }
    }


    private void ResetScene()
    {
        ResetPlayers();
        ResetBall();
        StartGame();
        BounceBall(ball);

        canScore = true;
    }
    

    private void GetDropDownManager()
    {
        // Look for the CharacterSelectDropdownManager component in the scene
        dropdownManager = FindObjectOfType<CharacterSelectDropdownManager>();

        // If we found it, log a message to the console
        if (dropdownManager != null)
        {
            Debug.Log("Found CharacterSelectDropdownManager component");
        }
        else
        {
            Debug.LogError("Could not find CharacterSelectDropdownManager component");
        }
    }



    public void ActivateActorsData()
    {
        // Spawn team 1 Actors
        team1Actors.Add(dropdownManager.CreateActor(1));
        team1Actors.Add(dropdownManager.CreateActor(2));

        // Spawn team 2 Actors
        team2Actors.Add(dropdownManager.CreateActor(3));
        team2Actors.Add(dropdownManager.CreateActor(4));
    }




    public void GoalTouched(Team scoredTeam)
    {
        if(canScore)
        {
            if (scoredTeam == Team.Blue)
            {
                scoreTeam1++;
                TMP_Score1.text = scoreTeam1.ToString();
            }
            else
            {
                scoreTeam2++;
                TMP_Score2.text = scoreTeam2.ToString();
            }
        
            canScore = false;

            DelayedRestart();
        }
    }


    //Reset Timer Management
    public float delayTime = 1.5f; // the number of seconds to wait before calling ResetScene
    void DelayedRestart () {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay () {
        yield return new WaitForSeconds(delayTime);
        ResetScene();
    }


}
