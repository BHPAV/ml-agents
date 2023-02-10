using UnityEngine;
using System.Collections.Generic;

public class CardSelectManager : MonoBehaviour
{
     // List of game objects
    public List<GameObject> Characters;

    // Card prefab
    public GameObject cardPrefab;
    public GameObject cardSelectedPrefab;

    // List of instantiated prefabs
    private List<GameObject> instantiatedPrefabs = new List<GameObject>();

    //Selected Prefab Number in List
    public int selectedCardNumber;
    public CardManager selectedCM;
    public string titleText;


    private void Start()
    {
        CreateSelectedCard();
        CreateCards();
    }

    // Function to handle the selected card
    private void CardSelected(CardManager cardManager)
    {
        selectedCardNumber = cardManager.GetCardNumber();
        Debug.Log("Card " + selectedCardNumber + " selected");

        //Update the title on the Monitoring Card.
        //selectedCM.TitleUpdate(selectedCardNumber.ToString());
        titleText = selectedCardNumber.ToString();
    }

    private void CreateCards()
    {
        // Instantiate prefabs for each item in the list
        for (int i = 0; i < Characters.Count; i++)
        {
            GameObject instantiatedPrefab = Instantiate(cardPrefab, transform);
            instantiatedPrefabs.Add(instantiatedPrefab);

            // Update the CardManager with the card number
            CardManager cardManager = instantiatedPrefab.GetComponent<CardManager>();
            cardManager.cardNumber = i;
            cardManager.OnSelect.AddListener(() => CardSelected(cardManager));
        }
    }

    private void CreateSelectedCard()
    {
        GameObject instantiatedPrefab = Instantiate(cardSelectedPrefab, transform);
        instantiatedPrefabs.Add(instantiatedPrefab);

        selectedCM = instantiatedPrefab.GetComponent<CardManager>();
    }
}
