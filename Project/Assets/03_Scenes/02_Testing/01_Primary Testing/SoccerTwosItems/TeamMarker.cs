using UnityEngine;

public class TeamMarker : MonoBehaviour
{
    public float radius = 1.0f; // radius of the circle
    public int numSegments = 32; // number of segments in the circle
    public bool isBlue = true; // boolean to toggle between blue and purple color

    void OnDrawGizmos()
    {
        if (isBlue)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = new Color(0.5f, 0, 0.5f); // purple color
        }

        Gizmos.DrawWireSphere(transform.position, radius);
    }
}