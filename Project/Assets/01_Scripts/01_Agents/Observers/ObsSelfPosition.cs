using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class ObsSelfPosition : MonoBehaviour
{
    [Observable(numStackedObservations: 3)]
    Vector3 Position 
    {
        get
        {
            Vector3 pos = gameObject.transform.position;
            pos = pos.normalized;
            return pos;
        }
    }
}
