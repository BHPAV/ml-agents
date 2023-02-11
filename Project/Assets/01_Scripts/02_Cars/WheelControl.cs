using UnityEngine;
using Sirenix.OdinInspector;

public class WheelControl : MonoBehaviour
{
    // Constants
    private const float SkidThreshold = 0.9f;
    private const float RPMThreshold = 10f;

    // Model game object
    [Title("Model")]
    [Tooltip("The visual representation of the wheel.")]
    private GameObject model;

    // Wheel collider component
    [Title("Wheel Collider")]
    [Tooltip("The collider component for the wheel.")]
    private WheelCollider wheelCollider;

    // Steering capability
    [Title("Steering")]
    [Tooltip("Indicates whether the wheel can steer.")]
    public bool canSteer;

    // Power capability
    [Title("Power")]
    [Tooltip("Indicates whether the wheel can apply power.")]
    public bool canPower;






    private void Start()
    {
        // Check if the wheel collider is null
        if (wheelCollider == null)
        {
            GetWheelCollider();
            GetWheelModel();
            //Debug.LogError("Wheel collider is not assigned.");
            //return;
        }

        // Enable/disable steering capability based on the "canSteer" bool
        wheelCollider.steerAngle = canSteer ? 30f : 0f;
    }

    private void Update()
    {
        // Check if the model game object is null
        if (model == null)
        {
            Debug.LogError("Model is not assigned.");
            return;
        }

        // Rotate the visual model based on the position of the wheel collider
        model.transform.rotation = wheelCollider.transform.rotation;
    }

    private void GetWheelCollider()
    {
        Transform colliderTransform = transform.Find("Collider");
        if (colliderTransform != null)
        {
            wheelCollider = colliderTransform.GetComponent<WheelCollider>();
            if (wheelCollider == null)
            {
                Debug.LogError("Child object named 'Collider' does not have a WheelCollider component attached.");
            }
        }
        else
        {
            Debug.LogError("Child object named 'Collider' not found.");
        }
    }


    private void GetWheelModel()
    {
        Transform modelTransform = transform.Find("Model");
        if (modelTransform != null)
        {
            model = modelTransform.gameObject;
        }
        else
        {
            Debug.LogError("Child object named 'Model' not found.");
        }
    }






    [Title("Torque")]
    public void ApplyTorque(float torque)
    {
        // Check if the wheel collider is null
        if (wheelCollider == null)
        {
            Debug.LogError("Wheel collider is not assigned.");
            return;
        }

        // Apply the specified torque to the wheel collider if the wheel can apply power
        if (canPower)
        {
            wheelCollider.motorTorque = torque;
        }
        else
        {
            wheelCollider.motorTorque = 0f;
        }
    }



    [Title("Grounded")]
    public bool IsGrounded()
    {
        // Check if the wheel collider is null
        if (wheelCollider == null)
        {
            Debug.LogError("Wheel collider is not assigned.");
            return false;
        }

        // Check if the wheel is touching the ground
        WheelHit hit;
        return wheelCollider.GetGroundHit(out hit);
    }



    [Title("Skidding")]
    public bool IsSkidding()
    {
        // Check if the wheel collider is null
        if (wheelCollider == null)
        {
            Debug.LogError("Wheel collider is not assigned.");
            return false;
        }

        // Check if the wheel is skidding
        WheelHit hit;
        wheelCollider.GetGroundHit(out hit);
        return Mathf.Abs(hit.sidewaysSlip) >= SkidThreshold || (Mathf.Abs(hit.forwardSlip) >= SkidThreshold && wheelCollider.rpm > RPMThreshold);
    }
}
