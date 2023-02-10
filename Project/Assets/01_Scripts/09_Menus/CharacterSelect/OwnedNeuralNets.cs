using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnedNeuralNets : MonoBehaviour
{
    [SerializeField] private List<GameObject> listNeuralNets = new List<GameObject>();
    [SerializeField] private int selectedNeuralNet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectNeuralNet(int _listPos)
    {
        selectedNeuralNet = _listPos;
    }
}
