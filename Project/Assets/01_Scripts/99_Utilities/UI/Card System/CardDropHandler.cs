using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropHandler : MonoBehaviour, IDropHandler
{
    public CardSelectionSystem selectionSystem;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject card = eventData.pointerDrag;
        selectionSystem.OnCardDropped(card);
    }
}
