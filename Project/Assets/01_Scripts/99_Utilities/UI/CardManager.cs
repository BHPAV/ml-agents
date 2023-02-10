using UnityEngine;
using UnityEngine.Events;

using TMPro;



public class CardManager : MonoBehaviour
{
    // Variable to store the card number
    public int cardNumber;

    // Variables to store the child objects
    public Transform title;
    public Transform image;

    // Public variable to track the selected state
    public bool Selected = false;

    // Event to announce when the card is selected
    public UnityEvent OnSelect;

    private void Awake()
    {
        // Find and store the child objects
        title = transform.Find("Title");
        image = transform.Find("Image");
    }

    // Function to return the card number
    public int GetCardNumber()
    {
        return cardNumber;
    }

    // Function to change the selected state and announce the event
    public void Select()
    {
        Selected = true;
        OnSelect.Invoke();
    }

    public void TitleUpdate(string _newText)
    {
        TextMeshPro tmp = title.gameObject.GetComponent<TextMeshPro>();
        tmp.text = _newText;
    }



    public void UpdateTitle(string _titleText)
    {
        Transform titleTransform = transform.Find("Title");
        if (titleTransform != null)
        {
            TextMeshPro textMeshPro = titleTransform.GetComponent<TextMeshPro>();
            if (textMeshPro != null)
            {
                textMeshPro.text = _titleText;
            }
        }
    }

}