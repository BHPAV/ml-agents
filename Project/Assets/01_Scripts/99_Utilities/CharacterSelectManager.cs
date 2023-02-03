using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] private LoadingScreen Loading;
    [SerializeField] private GameObject Agent1;
    [SerializeField] private GameObject Agent2;
    [SerializeField] private GameObject Agent3;

    public GameObject SelectedPrefab;

    public GameObject foundAgent;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene " + scene.name + " has been loaded");
        FindAgent();
    }






    public void SelectAgent(int _agentNumber)
    {
        switch(_agentNumber)
        {
            case 1: { SelectedPrefab = Agent1; } break;
            case 2: { SelectedPrefab = Agent2; } break;
            case 3: { SelectedPrefab = Agent3; } break; 
        }
    }


    public void FindAgent()
    {
        foundAgent = GameObject.FindWithTag("agent");
        if (foundAgent != null)
        {
            Debug.Log("Found agent: " + foundAgent.name);
            
            SpawnAgent agentSpawner = foundAgent.GetComponent<SpawnAgent>();
            agentSpawner.UpdateAgent(SelectedPrefab);
        }
        else
        {
            Debug.LogError("No agent found with tag 'agent'");
        }

        JobDone();
    }


    public void JobDone()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Destroy(gameObject);
    }

    




}
