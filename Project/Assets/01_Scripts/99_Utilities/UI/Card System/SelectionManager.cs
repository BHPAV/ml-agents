using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private CardData selectedCard;

    public void SetSelectedCard(CardData cardData)
    {
        selectedCard = cardData;
        Debug.Log("Selected card: " + selectedCard.cardName);
    }

    public CardData GetSelectedCard()
    {
        return selectedCard;
    }
}