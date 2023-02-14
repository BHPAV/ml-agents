using UnityEngine;

public class EngineController : MonoBehaviour
{
    private WheelControl[] wheelControls;
    public float motorTorque = 400f;
    public float torque = 0.0f;

    private void Start()
    {
        // Find all child objects with the WheelControl component attached
        wheelControls = GetComponentsInChildren<WheelControl>();
    }

    private void Update()
    {
        // Do something here
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Do something when the up arrow key is pressed
            torque = motorTorque;
        }
        else
        {
            torque = 0;
        }

        Accelerate();
    }

    public void Accelerate()
    {
        // Loop through all WheelControl scripts in the list
        foreach (WheelControl wheel in wheelControls)
        {
            // Call the ApplyTorque function on each WheelControl with the motorTorque value
            wheel.ApplyTorque(torque);
        }
    }
}