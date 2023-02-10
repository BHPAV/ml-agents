using UnityEngine;
using UnityEngine.UI;

public class ModelCameraCreator : MonoBehaviour
{
    public GameObject prefab;
    public RawImage image;

    private GameObject spawnedObject;
    private Camera cameraXX;

    private void Start()
    {
        // Create the object off-screen
        spawnedObject = Instantiate(prefab, new Vector3(-1000, 0, 0), Quaternion.identity);

        // Create a camera to view the object on the UI
        GameObject cameraGO = new GameObject("PreviewCamera");
        cameraXX = cameraGO.AddComponent<Camera>();
        cameraXX.clearFlags = CameraClearFlags.Depth;
        cameraXX.backgroundColor = Color.black;
        cameraXX.orthographic = true;
        cameraXX.orthographicSize = 2;
        cameraXX.nearClipPlane = 0.3f;
        cameraXX.farClipPlane = 1000;
        cameraXX.targetDisplay = 2;

        // Set the camera's position to look at the object
        cameraXX.transform.position = new Vector3(0, 0, -10);
        cameraXX.transform.LookAt(spawnedObject.transform);

        // Set the camera's render texture as the source for the UI image
        cameraXX.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        image.texture = cameraXX.targetTexture;
    }

    public void ChangeView(GameObject newObject)
    {
        // Set the camera to look at the new object
        cameraXX.transform.LookAt(newObject.transform);
        spawnedObject = newObject;
    }
}