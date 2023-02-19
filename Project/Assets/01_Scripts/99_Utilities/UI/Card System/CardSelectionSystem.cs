using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelectionSystem : MonoBehaviour
{
    public SelectionManager selection;

    public string stringSelection;

    public void OnCardDropped(GameObject card)
    {
        CardData cardData = card.GetComponent<CardData>();
        selection.SetSelectedCard(cardData);
        
        stringSelection = cardData.cardName;
    }
}






