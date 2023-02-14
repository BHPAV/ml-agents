using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float damping = 2.0f;

    void LateUpdate()
    {
        Vector3 wantedPosition = target.position - target.forward * distance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        transform.LookAt(target);
    }
}
