using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicalDetails : MonoBehaviour
{
    
    


    //Important Parts
    public GameObject m_Body;
    


    //Wheels
    //Public Variables
    [Header("Wheel Colliders")]
    public List<WheelCollider> Front_Wheels; //The front wheels (Wheel Colliders)
    public List<WheelCollider> Back_Wheels; //The rear wheels (Wheel Colliders)

    [Space(10)]

    [Header("Wheel Transforms")]
    public List<Transform> Front_Wheel_Transforms; //The front wheel transforms
    public List<Transform> Back_Wheel_Transforms; //The rear wheel transforms

    [Space(10)]

    [Header("Wheel Transforms Rotations")]
    public List<Vector3> Front_Wheel_Rotation; //The front wheel rotation Vectors
    public List<Vector3> Back_Wheel_Rotation; //The rear wheel rotation Vectors


}
