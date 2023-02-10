using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class LevelSpawnPointManager : MonoBehaviour
{
    public List<Transform> player1Spawns = new List<Transform>();
    public List<Transform> player2Spawns = new List<Transform>();

    public Vector3 GetSpawnPoint(int playerId)
    {
        if (playerId == 1)
        {
            int randomIndex = Random.Range(0, player1Spawns.Count);
            return player1Spawns[randomIndex].position;
        }
        else if (playerId == 2)
        {
            int randomIndex = Random.Range(0, player2Spawns.Count);
            return player2Spawns[randomIndex].position;
        }
        else
        {
            Debug.LogError("Invalid player ID");
            return Vector3.zero;
        }
    }

    public Quaternion GetSpawnRotation(int playerId)
    {
        if (playerId == 1)
        {
            int randomIndex = Random.Range(0, player1Spawns.Count);
            return player1Spawns[randomIndex].rotation;
        }
        else if (playerId == 2)
        {
            int randomIndex = Random.Range(0, player2Spawns.Count);
            return player2Spawns[randomIndex].rotation;
        }
        else
        {
            Debug.LogError("Invalid player ID");
            return Quaternion.identity;
        }
    }
}