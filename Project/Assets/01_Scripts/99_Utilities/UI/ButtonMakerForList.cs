using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonMakerForList : MonoBehaviour
{
    public List<GameObject> objectsList;
    public GameObject buttonPrefab;

    private void Start()
    {
        // Loop through the list of objects
        for (int i = 0; i < objectsList.Count; i++)
        {
            // Instantiate a new button using the button prefab
            GameObject button = Instantiate(buttonPrefab, transform);

            // Set the text of the button to be the name of the current object in the list
            button.GetComponentInChildren<Text>().text = objectsList[i].name;

            // Add a listener to the button's onClick event that will activate the current object in the list
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => ActivateObject(index));
        }
    }

    private void ActivateObject(int index)
    {
        // Activate the object at the specified index in the list
        objectsList[index].SetActive(true);
    }
}