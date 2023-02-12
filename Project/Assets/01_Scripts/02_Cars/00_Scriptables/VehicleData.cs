using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;



[CreateAssetMenu(menuName = "Vehicle Data")]
public class VehicleData : ScriptableObject
{
    [BoxGroup("Vehicle Info")]
    [LabelText("Vehicle Name")]
    public string dataName;

    [BoxGroup("Vehicle Components")]
    [LabelText("Body")]
    public GameObject m_Body;

    [BoxGroup("Vehicle Components")]
    [LabelText("Wheel")]
    public GameObject m_Wheel;

    [BoxGroup("Vehicle Info")]
    [LabelText("Center of Gravity")]
    public Transform centerOfGravity;

    [BoxGroup("Vehicle Info")]
    [LabelText("Wheel Positions")]
    public List<Transform> wheelPositions;

    [BoxGroup("Vehicle Physics")]
    [LabelText("Mass (kg)")]
    public float mass;

    [BoxGroup("Vehicle Physics")]
    [LabelText("Motor Torque (Nm)")]
    public float motorTorque;

    [BoxGroup("Vehicle Physics")]
    [LabelText("Max Steer Angle (deg)")]
    public float maxSteerAngle;

    [BoxGroup("Vehicle Physics")]
    [LabelText("Brake Force (N)")]
    public float brakeForce;

    [BoxGroup("Vehicle Physics")]
    [LabelText("Maximum Speed (km/h)")]
    public float maximumSpeed;
}
