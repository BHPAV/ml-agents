using Unity.Barracuda;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Serialization;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;




public class AgentSelectManager : MonoBehaviour
{
    
    public List<NNModel> m_NeuralNetList = new List<NNModel>();
    public List<GameObject> m_ModelList = new List<GameObject>();

    public NNModel m_SelectedNeuralNet;
    public GameObject m_SelectedModel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void SelectNeuralNet(int _selection)
    {
        if(_selection < m_NeuralNetList.Count)
            m_SelectedNeuralNet = m_NeuralNetList[_selection];
    }

    public void SelectModel(int _selection)
    {
        if(_selection < m_ModelList.Count)
            m_SelectedModel = m_ModelList[_selection];
    }

    

}
