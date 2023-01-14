using UnityEngine;

public class CameraOrbiter : MonoBehaviour
{
    public Transform orbitTarget;
    public float orbitSpeed = 10f;

    void Update()
    {
        transform.RotateAround(orbitTarget.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}