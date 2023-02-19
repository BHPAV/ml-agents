using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeAway : MonoBehaviour
{
    public float fadeTime = 1f; // The time it takes for the element to fade away
    private Image image; // Reference to the image component of the UI element

    private void Start()
    {
        image = GetComponent<Image>(); // Get the image component of the UI element
    }

    public void StartFade()
    {
        StartCoroutine(Fade()); // Start the fading process
    }

    private IEnumerator Fade()
    {
        float t = 0f; // Initialize the elapsed time to 0

        while (t < fadeTime)
        {
            t += Time.deltaTime; // Add the time elapsed since the last frame
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime); // Calculate the current alpha value using a linear interpolation
            Color newColor = image.color; // Get the current color of the UI element
            newColor.a = alpha; // Set the alpha component of the color
            image.color = newColor; // Update the color of the UI element
            yield return null; // Wait until the next frame
        }

        gameObject.SetActive(false); // Disable the UI element when it has faded away
    }
}
