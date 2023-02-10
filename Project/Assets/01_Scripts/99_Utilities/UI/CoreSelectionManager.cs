using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CoreSelectionManager : MonoBehaviour
{
    public GameObject[] Models;
    public GameObject[] Brains;

    [SerializeField] private GameObject selectedModel;
    [SerializeField] private GameObject selectedBrain;

    public void AssignModel(int index)
    {
        selectedModel = Models[index];
    }

    public void AssignBrain(int index)
    {
        selectedBrain = Brains[index];
    }
}