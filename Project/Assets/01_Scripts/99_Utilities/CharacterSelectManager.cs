using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    [SerializeField] private LoadingScreen Loading;
    [SerializeField] private GameObject Agent1;
    [SerializeField] private GameObject Agent2;
    [SerializeField] private GameObject Agent3;

    public GameObject SelectedAgent;




    public void SelectAgent(int _agentNumber)
    {
        switch(_agentNumber)
        {
            case 1: { SelectedAgent = Agent1; } break;
            case 2: { SelectedAgent = Agent2; } break;
            case 3: { SelectedAgent = Agent3; } break; 
        }
        
        Loading.prefabToTransfer = SelectedAgent;
    }



    public void TriggerNextLevel()
    {

    }




}
