using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    private Vector3 previousPosition;
    private float totalDistanceMoved;
    public TMP_Text distanceText;
    public GameObject objectToTrack;

    private void Start()
    {
        previousPosition = objectToTrack.transform.position;
    }

    private void Update()
    {
        float distanceMoved = Vector3.Distance(previousPosition, objectToTrack.transform.position);
        totalDistanceMoved += distanceMoved;
        previousPosition = objectToTrack.transform.position;
        UpdateDistanceText();
    }

    private void UpdateDistanceText()
    {
        distanceText.text = totalDistanceMoved.ToString("F2") + " M";
    }
}
