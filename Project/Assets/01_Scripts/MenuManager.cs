using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{
    private int lastSceneIndex;

    private void Start()
    {
        // Save the index of the current scene
        lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        
    }
}
