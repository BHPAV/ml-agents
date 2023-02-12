using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skidmarks : MonoBehaviour
{

    public WheelCollider wheelCollider;
    public TrailRenderer skidTrail;
    public ParticleSystem smoke;

    // Constants
    private const float SkidThreshold = 0.9f;
    private const float RPMThreshold = 10f;


    // Testing
    public bool Skidding;
    public bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        //skidMarkPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OriginalCode();
        IsGrounded();
        IsSkidding();
    }



    private void OriginalCode()
    {
        RaycastHit hit;
        Vector3 ColliderCenterPoint = wheelCollider.transform.TransformPoint( wheelCollider.center );


        float suspensionDist = wheelCollider.suspensionDistance;
        float CCR = wheelCollider.radius;

        // now cast a ray out from the wheel collider's center the distance of the suspension, if it hit something, then use the "hit"
        // variable's data to find where the wheel hit, if it didn't, then se tthe wheel to be fully extended along the suspension.
        if ( Physics.Raycast( ColliderCenterPoint, -wheelCollider.transform.up,out hit, suspensionDist + CCR ) ) {
            transform.position = hit.point + (wheelCollider.transform.up * wheelCollider.radius);
        }else{
            transform.position = ColliderCenterPoint - (wheelCollider.transform.up * wheelCollider.suspensionDistance);
        }

        // define a wheelhit object, this stores all of the data from the wheel collider and will allow us to determine
        // the slip of the tire.
        WheelHit CorrespondingGroundHit;
        wheelCollider.GetGroundHit(out CorrespondingGroundHit );
        
        // if the slip of the tire is greater than 2.0, and the slip prefab exists, create an instance of it on the ground at
        // a zero rotation.
        if ( Mathf.Abs( CorrespondingGroundHit.sidewaysSlip ) > .8 )
            {
            //skidMarkPrefab.gameObject.active = true;
                //skidMarkPrefab.SetActive(true);
                skidTrail.emitting = true;
                smoke.Play();
            }
        else if ( Mathf.Abs( CorrespondingGroundHit.sidewaysSlip ) <= .75 )
            {
            //skidMarkPrefab.gameObject.active = false;
                //skidMarkPrefab.SetActive(false);
                skidTrail.emitting = false;
                smoke.Stop();
            }
    }




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
