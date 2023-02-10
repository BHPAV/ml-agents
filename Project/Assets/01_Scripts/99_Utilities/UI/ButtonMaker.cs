using UnityEngine;
using UnityEngine.UI;

public class ButtonMaker : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        // Create a new button game object
        button = new GameObject("Button", typeof(RectTransform), typeof(Image), typeof(Button)).GetComponent<Button>();

        // Set the parent of the button to be the canvas
        button.transform.SetParent(GetComponent<RectTransform>(), false);

        // Set the size of the button to be 100x100
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

        // Add a listener to the button's onClick event
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        Debug.Log("Button was clicked");
    }
}