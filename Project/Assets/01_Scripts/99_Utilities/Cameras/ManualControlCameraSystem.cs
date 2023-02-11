using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ManualControlCameraSystem : MonoBehaviour
{
    public Transform targetTransform;
    public float lerpSpeed = 5f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isReturning = false;

    private void Start()
    {
        // Store the initial position and rotation of the camera
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ChangePosition()
    {
        // Start the coroutine to lerp the position and rotation of the camera
        StartCoroutine(LerpCamera());
    }

    private IEnumerator LerpCamera()
    {
        Vector3 currentStartPosition = transform.position;
        Vector3 targetPosition;
        Quaternion currentStartRotation = transform.rotation;
        Quaternion targetRotation;

        if (!isReturning)
        {
            // If the camera is not returning, set the target position and rotation to be the same as the targetTransform
            targetPosition = targetTransform.position;
            targetRotation = targetTransform.rotation;
        }
        else
        {
            // If the camera is returning, set the target position and rotation to be the same as the starting position and rotation
            targetPosition = startPosition;
            targetRotation = startRotation;
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * lerpSpeed;
            transform.position = Vector3.Lerp(currentStartPosition, targetPosition, t);
            transform.rotation = Quaternion.Lerp(currentStartRotation, targetRotation, t);
            yield return null;
        }

        // Set the flag to indicate if the camera is returning or not
        isReturning = !isReturning;
    }
}
