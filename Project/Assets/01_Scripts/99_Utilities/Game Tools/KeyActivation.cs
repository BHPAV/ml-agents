using UnityEngine;

public class KeyActivation : MonoBehaviour
{
    public GameObject ObjectToControl;
    public KeyCode activationKey;

    [Header("Inspector Options")]
    private KeyCode[] keyOptions =
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
        KeyCode.Space,
        KeyCode.Return,
        KeyCode.Tab,
        KeyCode.Escape
    };

    private void Update()
    {
        if (Input.GetKeyDown(activationKey))
            Activate();
    }


    public void Activate()
    {
        ObjectToControl.SetActive(!ObjectToControl.activeSelf);
    }
}
