using UnityEngine;

public class FiveInputManager : MonoBehaviour
{
    public float forwardAmount;
    public float turnAmount;
    public float breakAction;
    public float boostAction;
    public float otherAction;
    public CarDriver targetScript;
    public bool manualControl;

    private void Update()
    {
        if (targetScript == null)
            return;

        if (manualControl)
        {
            HeuristicInput();
        }
        else
        {
            ApplyInput();
        }
    }

    private void ApplyInput()
    {
        targetScript.ReceiveInput(forwardAmount, turnAmount, breakAction, boostAction, otherAction);
    }

    private void HeuristicInput()
    {
        // Your code for the HeuristicInput function
        int forwardAction = 0;
        if (Input.GetKey(KeyCode.UpArrow)) forwardAction = 1;
        if (Input.GetKey(KeyCode.DownArrow)) forwardAction = 2;

        int turnAction = 0;
        if (Input.GetKey(KeyCode.RightArrow)) turnAction = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) turnAction = 2;

        int _breakAction = 0;
        if (Input.GetKey(KeyCode.Space)) _breakAction = 1;

        int _boostAction = 0;
        if (Input.GetKey(KeyCode.LeftShift)) _boostAction = 1;

        int _generalAction = 0;
        if (Input.GetKey(KeyCode.F)) _generalAction = 1;

        forwardAmount = forwardAction;
        turnAmount = turnAction;
        breakAction = _breakAction;
        boostAction = _boostAction;
        otherAction = _generalAction;
    }
}