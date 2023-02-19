using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectDropdownManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> listNeuralNets_Team1 = new List<GameObject>();
    [SerializeField] private List<GameObject> listModels_Team1 = new List<GameObject>();

    [SerializeField] private List<GameObject> listNeuralNets_Team2 = new List<GameObject>();
    [SerializeField] private List<GameObject> listModels_Team2 = new List<GameObject>();

    public int Team1_Player1_Model, Team1_Player1_AI, Team1_Player2_Model, Team1_Player2_AI;
    public int Team2_Player1_Model, Team2_Player1_AI, Team2_Player2_Model, Team2_Player2_AI;




    // Start is called before the first frame update
    void Start()
    {
        
    }

 


    public Actor CreateActor(int _ActorNum)
    {
        Actor _newActor = new Actor(listModels_Team1[Team1_Player1_Model], listNeuralNets_Team1[Team1_Player1_AI]);

        switch(_ActorNum)
        {
            case 0: {} break;
            case 1: { _newActor = new Actor(listModels_Team1[Team1_Player1_Model], listNeuralNets_Team1[Team1_Player1_AI]);} break;
            case 2: { _newActor = new Actor(listModels_Team1[Team1_Player2_Model], listNeuralNets_Team1[Team1_Player2_AI]);} break;
            case 3: { _newActor = new Actor(listModels_Team2[Team2_Player1_Model], listNeuralNets_Team2[Team2_Player1_AI]);} break;
            case 4: { _newActor = new Actor(listModels_Team2[Team2_Player2_Model], listNeuralNets_Team2[Team2_Player2_AI]);} break; 
        }

        return _newActor;
    }




    public void SetModel_Team1_Player1(int selection)
    {
        Team1_Player1_Model = selection;
    }

    public void SetModel_Team1_Player2(int selection)
    {
        Team1_Player2_Model = selection;
    }

    public void SetAI_Team1_Player1(int selection)
    {
        Team1_Player1_AI = selection;
    }

    public void SetAI_Team1_Player2(int selection)
    {
        Team1_Player2_AI = selection;
    }



    public void SetModel_Team2_Player1(int selection)
    {
        Team2_Player1_Model = selection;
    }

    public void SetModel_Team2_Player2(int selection)
    {
        Team2_Player2_Model = selection;
    }

    public void SetAI_Team2_Player1(int selection)
    {
        Team2_Player1_AI = selection;
    }

    public void SetAI_Team2_Player2(int selection)
    {
        Team2_Player2_AI = selection;
    }






}
