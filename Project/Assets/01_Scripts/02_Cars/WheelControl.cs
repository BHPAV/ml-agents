using UnityEngine;
using Sirenix.OdinInspector;

public class WheelControl : MonoBehaviour
{
    
    // Model game object
    [Title("Model")]
    [Tooltip("The visual representation of the wheel.")]
    [SerializeField] private GameObject model;

    // Wheel collider component
    [Title("Wheel Collider")]
    [Tooltip("The collider component for the wheel.")]
    [SerializeField] private WheelCollider wheelCollider;
    [SerializeField] private Quaternion wheelRotation ;

    // Steering capability
    [Title("Steering")]
    [Tooltip("Indicates whether the wheel can steer.")]
    public bool canSteer;

    // Power capability
    [Title("Power")]
    [Tooltip("Indicates whether the wheel can apply power.")]
    public bool canPower;



    //Particles
    public TrailRenderer skidTrail;
    public ParticleSystem smoke;

    // Constants
    [SerializeField] private float SkidThreshold = 0.8f;
    [SerializeField] private float RPMThreshold = 5.0f;

    public bool Skidding;
    public bool Grounded;



    private void Start()
    {
        // Check if the wheel collider is null
        if (wheelCollider == null)
        {
            GetWheelCollider();
            GetWheelModel();
            GetEffects();
        }
    }

    private void Update()
    {
        /*
        // Check if the model game object is null
        if (model == null)
        {
            Debug.LogError("Model is not assigned.");
            return;
        }
        

        // Rotate the visual model based on the position of the wheel collider
        model.transform.rotation = wheelCollider.transform.rotation;
        

        //TESTING UPDATES
        Grounded = IsGrounded();
        Skidding = IsSkidding();

        EffectCheck();

        wheelRotation = wheelCollider.transform.rotation;
        */
    }

    private void GetEffects()
    {
        Transform fxTransform = transform.Find("FX");
        if (fxTransform != null)
        {
            skidTrail = fxTransform.GetComponent<TrailRenderer>();
            smoke = fxTransform.GetComponent<ParticleSystem>();
        }
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


    [Title("Smoking")]
    public bool IsSmoking()
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



    private void EffectCheck()
    {
        if(IsSkidding() && IsGrounded())
            skidTrail.emitting = true;
        else    
            skidTrail.emitting = false;
    }



    private void WheelRotation()
    {

    }

    
    
}
