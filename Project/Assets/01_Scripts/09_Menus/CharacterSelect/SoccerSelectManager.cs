using System.Collections.Generic;
using UnityEngine;

public class SoccerSelectManager : MonoBehaviour
{
    public List<GameObject> listModels;
    public List<GameObject> listAgentCores;

    void Start()
    {
        
    }



    private void CreateModels()
    {
        // Instantiate each of the models in the listModels
        foreach (GameObject model in listModels)
        {
            Instantiate(model, transform.position, Quaternion.identity);
        }
    }
}