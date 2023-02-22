using System.Collections.Generic;
using System.Collections;

using UnityEngine;

public class SumoGameManager : MonoBehaviour
{
    public List<GameObject> team1Objects;
    public List<GameObject> team2Objects;

    public List<Actor> team1Actors;
    public List<Actor> team2Actors;

    public Transform[] spawnPoints;

    private bool isGameOver;
    public bool isTraining;

    void Start()
    {
        GetActorLists();
        GetSpawnPoints();
        SpawnActors();
        ResetScene();
    }


    void Update()
    {
        GameCheck();
    }

    private void GameCheck()
    {
        if (!isGameOver)
        {
            bool team1Lost = true;
            bool team2Lost = true;

            // Check if any team 1 objects are above -5f Y
            foreach (GameObject obj in team1Objects)
            {
                if (obj.transform.position.y > -5f)
                {
                    team1Lost = false;
                    break;
                }
            }

            // Check if any team 2 objects are above -5f Y
            foreach (GameObject obj in team2Objects)
            {
                if (obj.transform.position.y > -5f)
                {
                    team2Lost = false;
                    break;
                }
            }

            if (team1Lost)
            {
                Debug.Log("Team 2 wins!");
                isGameOver = true;

                RewardTeamOne(-1.0f);
                ResetScene();
            }
            else if (team2Lost)
            {
                Debug.Log("Team 1 wins!");
                isGameOver = true;

                RewardTeamOne(1.0f);
                ResetScene();
            }
        }
    }


    private void TrainingReward(GameObject _obj, float _reward)
    {
        if(isTraining)
        {
            AgentCore _agent = _obj.GetComponentInChildren<AgentCore>();

            if(_agent != null)
            {
                _agent.AddReward(_reward);
                _agent.EndEpisode();
            }
        }
    }


    private void RewardTeamOne(float _reward)
    {
        // WHAAAAAA
        foreach (GameObject obj in team1Objects)
        {
            TrainingReward(obj, _reward);
        }
    }



    private void GetSpawnPoints()
    {
        Transform spawnPointsTransform = transform.Find("SpawnPoints");
        if (spawnPointsTransform != null)
        {
            List<Transform> spawnPointList = new List<Transform>();
            foreach (Transform child in spawnPointsTransform)
            {
                spawnPointList.Add(child);
            }
            spawnPoints = spawnPointList.ToArray();
        }
        else
        {
            Debug.LogError("SpawnPoints gameobject not found!");
        }
    }


    void MoveObjectsToUniquePositions(List<GameObject> objectsToMove)
    {
        if (objectsToMove != null)
        {
            int numObjects = objectsToMove.Count;
            if (numObjects > spawnPoints.Length)
            {
                Debug.LogWarning("Not enough spawn points for all objects!");
            }
            for (int i = 0; i < numObjects && i < spawnPoints.Length; i++)
            {
                Transform spawnPoint = spawnPoints[i];
                GameObject objectToMove = objectsToMove[i];

                // Move the object to the spawn point position and rotation
                objectToMove.transform.position = spawnPoint.position;
                objectToMove.transform.rotation = spawnPoint.rotation;

                // Zero out the object's velocity to avoid unwanted movement
                Rigidbody objectRigidbody = objectToMove.GetComponent<Rigidbody>();
                if (objectRigidbody != null)
                {
                    objectRigidbody.velocity = Vector3.zero;
                    objectRigidbody.angularVelocity = Vector3.zero;
                    objectRigidbody.isKinematic = true;
                }
            }
        }
    }


    public List<GameObject> ConcatenateLists(List<GameObject> _list1, List<GameObject> _list2)
    {
        List<GameObject> concatenatedList = new List<GameObject>();
        concatenatedList.AddRange(_list1);
        concatenatedList.AddRange(_list2);
        return concatenatedList;
    }



    private void ResetScene()
    {
        isGameOver = false;


        MoveObjectsToUniquePositions(ConcatenateLists(team1Objects, team2Objects));

        if(isTraining)
        {
            StartGame();
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

            //Freeze in place prior to game start
            obj.GetComponent<Rigidbody>().isKinematic = true;
            
            team1Objects.Add(obj);

            obj.transform.SetParent(this.transform);
        }

        // Spawn team 2 gameobjects
        for (int i = 0; i < team2Actors.Count; i++)
        {
            team2Actors[i].CreateActor();

            GameObject obj = team2Actors[i].GetModel();
            obj.name = "Team 2 Player " + (i + 1);

            //Freeze in place prior to game start
            obj.GetComponent<Rigidbody>().isKinematic = true;

            team2Objects.Add(obj);

            obj.transform.SetParent(this.transform);
        }
    }


    public void StartGame()
    {
        // Unfreeze team 1 gameobjects
        for (int i = 0; i < team1Objects.Count; i++)
        {
            team1Objects[i].GetComponent<Rigidbody>().isKinematic = false;
        }

        // Unfreeze team 2 gameobjects
        for (int i = 0; i < team2Objects.Count; i++)
        {
            team2Objects[i].GetComponent<Rigidbody>().isKinematic = false;
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

    private GameObject actorSelectionLists; // this variable will hold a reference to the ActorSelectionLists GameObject
    private void GetActorLists()
    {
        // find the ActorSelectionLists GameObject by name and assign it to the actorSelectionLists variable
        actorSelectionLists = GameObject.Find("ActorSelectionLists");

        if (actorSelectionLists == null)
        {
            Debug.LogError("Could not find ActorSelectionLists GameObject.");
        }
        else
        {
            ActorSelectionLists _ASL = actorSelectionLists.GetComponent<ActorSelectionLists>();
            team1Actors = _ASL.GetTeamActors(1);
            team2Actors = _ASL.GetTeamActors(2);
        }


    }


}
