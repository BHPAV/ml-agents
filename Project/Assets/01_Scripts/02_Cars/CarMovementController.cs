using UnityEngine;

public class CarMovementController : MonoBehaviour
{
    [Tooltip("The speed at which the car will move forward.")]
    public float speed = 10f;

    [Tooltip("The wheels attached to the car.")]
    public WheelControl[] wheels;




    private void Start()
    {
        FindWheels();
    }

    private void Update()
    {
        // Apply forward torque to the wheels
        foreach (var wheel in wheels)
        {
            wheel.ApplyTorque(speed);
        }
    }







    private void FindWheels()
    {
        // Find all the WheelControl scripts attached to child objects
        wheels = GetComponentsInChildren<WheelControl>();
    }
}