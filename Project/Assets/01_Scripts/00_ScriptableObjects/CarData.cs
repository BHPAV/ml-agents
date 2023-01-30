using UnityEngine;

[CreateAssetMenu(fileName = "New Car Data", menuName = "Car Data")]
public class CarData : ScriptableObject
{
    public GameObject carPrefab;
    public float topSpeed;
    public float acceleration;
    public float handling;
    public float braking;
}