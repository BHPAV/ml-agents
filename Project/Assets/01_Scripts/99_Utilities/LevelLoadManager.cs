using UnityEngine;
using Sirenix.OdinInspector;

public class LevelLoadManager : MonoBehaviour
{

    public bool TrainingMode;



    [Title("Prefabs")]
    [SerializeField]
    [AssetSelector]
    public GameObject ArenaPrefab;
    [SerializeField]
    [AssetSelector]
    public GameObject Player1Prefab;
    [SerializeField]
    [AssetSelector]
    public GameObject Player2Prefab;

    private GameObject arena;
    private GameObject player1;
    private GameObject player2;
    private float previousTimeScale;

    // Use this for initialization
    private void Start()
    {
        LoadArena();
        SpawnPlayers();

        if(TrainingMode)
            UnpauseGame();

    }

    // Instantiates the ArenaPrefab and renames it to "Arena".
    public void LoadArena()
    {
        arena = Instantiate(ArenaPrefab, transform);
        arena.name = "Arena";
    }

    // Instantiates the Player1Prefab and Player2Prefab at the spawn points specified by the LevelSpawnPointManager
    public void SpawnPlayers()
    {
        LevelSpawnPointManager spawnPointManager = arena.GetComponent<LevelSpawnPointManager>();
        Vector3 spawnPoint1 = spawnPointManager.GetSpawnPoint(1);
        Quaternion spawnRotation1 = spawnPointManager.GetSpawnRotation(1);
        Vector3 spawnPoint2 = spawnPointManager.GetSpawnPoint(2);
        Quaternion spawnRotation2 = spawnPointManager.GetSpawnRotation(2);

        player1 = Instantiate(Player1Prefab, spawnPoint1, spawnRotation1, transform);
        player2 = Instantiate(Player2Prefab, spawnPoint2, spawnRotation2, transform);

        PauseGame();
    }

    // Pauses the game by setting the timescale to 0
    [Button]
    public void PauseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    // Unpauses the game by setting the timescale back to what it was before the game was paused
    [Button]
    public void UnpauseGame()
    {
        Time.timeScale = previousTimeScale;
    }


    public void ResetPlayers()
    {
        
    }
}