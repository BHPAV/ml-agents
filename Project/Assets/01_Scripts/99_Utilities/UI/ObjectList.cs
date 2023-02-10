using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectList : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public GameObject buttonPrefab;
    public int clickedObjectIndex;

    private void Start()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponentInChildren<Text>().text = gameObjects[i].name;
            int index = i;
            button.GetComponent<Button>().onClick.AddListener(() => ObjectClicked(index));
        }
    }

    private void ObjectClicked(int index)
    {
        clickedObjectIndex = index;
        Debug.Log("Clicked object index: " + clickedObjectIndex);
    }
}
