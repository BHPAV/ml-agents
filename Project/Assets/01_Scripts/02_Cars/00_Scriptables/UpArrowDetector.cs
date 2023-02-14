using UnityEngine;

public class UpArrowDetector : MonoBehaviour
{
    public WheelControl wheelControl;
    public WheelControl wheelControl2;
    public float torque = 400f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Do something when the up arrow key is pressed
            wheelControl.ApplyTorque(torque);
            wheelControl2.ApplyTorque(torque);
        }
    }
}