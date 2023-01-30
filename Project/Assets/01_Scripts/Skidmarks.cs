using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skidmarks : MonoBehaviour
{

    public WheelCollider CorrespondingCollider;
    public TrailRenderer skidTrail;
    public ParticleSystem smoke;


    // Start is called before the first frame update
    void Start()
    {
        //skidMarkPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 ColliderCenterPoint = CorrespondingCollider.transform.TransformPoint( CorrespondingCollider.center );


        float suspensionDist = CorrespondingCollider.suspensionDistance;
        float CCR = CorrespondingCollider.radius;

        // now cast a ray out from the wheel collider's center the distance of the suspension, if it hit something, then use the "hit"
        // variable's data to find where the wheel hit, if it didn't, then se tthe wheel to be fully extended along the suspension.
        if ( Physics.Raycast( ColliderCenterPoint, -CorrespondingCollider.transform.up,out hit, suspensionDist + CCR ) ) {
            transform.position = hit.point + (CorrespondingCollider.transform.up * CorrespondingCollider.radius);
        }else{
            transform.position = ColliderCenterPoint - (CorrespondingCollider.transform.up * CorrespondingCollider.suspensionDistance);
        }

        // define a wheelhit object, this stores all of the data from the wheel collider and will allow us to determine
	// the slip of the tire.
	WheelHit CorrespondingGroundHit;
	CorrespondingCollider.GetGroundHit(out CorrespondingGroundHit );
	
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
}
