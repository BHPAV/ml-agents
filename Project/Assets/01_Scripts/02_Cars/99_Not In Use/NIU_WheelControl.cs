using UnityEngine;
using Sirenix.OdinInspector;

namespace NotInUse.Vehicals
{
    public class WheelControl : MonoBehaviour
    {
        [Title("Model")]
        public GameObject Model { get; private set; }

        [Title("Wheel Collider")]
        public WheelCollider WheelCollider { get; private set; }

        [Title("Steering")]
        public bool CanSteer { get; private set; }

        [Title("Power")]
        public bool CanPower { get; private set; }

        void Start()
        {
            if (WheelCollider == null || Model == null)
            {
                Debug.LogError("WheelCollider or Model is not assigned in the Inspector.");
                return;
            }

            // Enable/disable steering capability based on the "CanSteer" bool
            WheelCollider.steerAngle = CanSteer ? 30 : 0;
        }

        void Update()
        {
            // Rotate the visual model based on the position of the wheel collider
            Model.transform.rotation = WheelCollider.transform.rotation;
        }

        [Title("Torque")]
        public void ApplyTorque(float torque)
        {
            // Apply the specified torque to the wheel collider if CanPower is true
            WheelCollider.motorTorque = CanPower ? torque : 0;
        }

        [Title("Grounded")]
        public bool IsGrounded()
        {
            // Check if the wheel is touching the ground
            return WheelCollider.GetGroundHit(out WheelHit hit);
        }

        [Title("Skidding")]
        public bool IsSkidding()
        {
            // Check if the wheel is skidding
            WheelCollider.GetGroundHit(out WheelHit hit);
            return Mathf.Abs(hit.sidewaysSlip) >= 0.9f || (Mathf.Abs(hit.forwardSlip) >= 0.9f && WheelCollider.rpm > 10);
        }
    }
}
