using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    
    public GameObject targetGameObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            targetGameObject.SetActive(!targetGameObject.activeSelf);
        }
    }


}
