using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OwnedModels : MonoBehaviour
{


    [SerializeField] private List<GameObject> listModels = new List<GameObject>();
    [SerializeField] private int selectedModel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectModel(int _listPos)
    {
        selectedModel = _listPos;
    }
}
