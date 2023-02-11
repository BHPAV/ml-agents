using UnityEngine;
using System.Collections.Generic;

public class ModelSelectManager : MonoBehaviour
{
    /*
    [SerializeField] private GameObject selectedCardPrefab;
    private OwnedModels ownedModels;

    private void Start()
    {
        // Get the OwnedModels component attached to the same gameobject
        ownedModels = GetComponent<OwnedModels>();

        // Check if the OwnedModels component is found
        if (ownedModels == null)
        {
            Debug.LogError("OwnedModels component not found in gameobject " + gameObject.name);
            return;
        }

        // Create a SelectedCardPrefab for each gameobject in the list
        foreach (GameObject model in ownedModels.listModels)
        {
            GameObject selectedCard = Instantiate(selectedCardPrefab, transform);
            selectedCard.GetComponent<CardManager>().SetModel(model);
        }
    }
    */
}