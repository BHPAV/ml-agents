using UnityEngine;
using Sirenix.OdinInspector;

public class WheelControl : MonoBehaviour
{
    [Title("Model")]
    public GameObject model;

    [Title("Wheel Collider")]
    public WheelCollider wheelCollider;

    [Title("Steering")]
    public bool canSteer;

    [Title("Power")]
    public bool canPower;

    void Start()
    {
        // Enable/disable steering capability based on the "canSteer" bool
        wheelCollider.steerAngle = canSteer ? 30 : 0;
    }

    void Update()
    {
        // Rotate the visual model based on the position of the wheel collider
        model.transform.rotation = wheelCollider.transform.rotation;
    }

    [Title("Torque")]
    public void ApplyTorque(float torque)
    {
        // Apply the specified torque to the wheel collider
        if (canPower)
        {
            wheelCollider.motorTorque = torque;
        }
        else
        {
            wheelCollider.motorTorque = 0;
        }
    }

    [Title("Grounded")]
    public bool IsGrounded()
    {
        // Check if the wheel is touching the ground
        WheelHit hit;
        return wheelCollider.GetGroundHit(out hit);
    }

    [Title("Skidding")]
    public bool IsSkidding()
    {
        // Check if the wheel is skidding
        WheelHit hit;
        wheelCollider.GetGroundHit(out hit);
        return Mathf.Abs(hit.sidewaysSlip) >= 0.9f || (Mathf.Abs(hit.forwardSlip) >= 0.9f && wheelCollider.rpm > 10);
    }
}