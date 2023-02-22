using UnityEngine;
using UnityEngine.UI;

public class SumoCharacterSelectManager : MonoBehaviour
{
    // Reference to the character selection panel
    public GameObject characterSelectionPanel;

    // Reference to the selected character's image
    public Image selectedCharacterImage;

    // Reference to the character selection buttons
    public Button[] characterSelectionButtons;

    // The index of the currently selected character
    private int selectedCharacterIndex;

    private void Start()
    {
        // Hide the character selection panel initially
        characterSelectionPanel.SetActive(false);

        // Add click listeners to the character selection buttons
        for (int i = 0; i < characterSelectionButtons.Length; i++)
        {
            int index = i;
            characterSelectionButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    public void ShowCharacterSelectionPanel()
    {
        // Show the character selection panel
        characterSelectionPanel.SetActive(true);
    }

    public void HideCharacterSelectionPanel()
    {
        // Hide the character selection panel
        characterSelectionPanel.SetActive(false);
    }

    public void SelectCharacter(int index)
    {
        // Update the selected character index
        selectedCharacterIndex = index;

        // Update the selected character image
        selectedCharacterImage.sprite = characterSelectionButtons[index].image.sprite;
    }

    public int GetSelectedCharacterIndex()
    {
        return selectedCharacterIndex;
    }
}
