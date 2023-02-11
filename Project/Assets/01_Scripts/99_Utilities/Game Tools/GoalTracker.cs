using UnityEngine;
using TMPro;

public class GoalTracker : MonoBehaviour
{
    private int eventCount = 0;
    public TextMeshPro eventCountText;
    private float timeSinceLastIncrement = 0f;
    private bool canIncrement = true;

    public TMP_Text TextUI;


    void Update() {
        if(!canIncrement) {
            timeSinceLastIncrement += Time.deltaTime;
            if(timeSinceLastIncrement >= 3f) {
                canIncrement = true;
                timeSinceLastIncrement = 0f;
            }
        }
    }

    public void IncrementEventCount() {
        if(canIncrement) {
            eventCount++;
            UpdateEventCountText();
            canIncrement = false;
        }
    }

    private void UpdateEventCountText(){
        if(eventCountText != null)
            eventCountText.text = eventCount.ToString();

        if(TextUI != null)
            TextUI.SetText(eventCount.ToString());
        
    }
}
