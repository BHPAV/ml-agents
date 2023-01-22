using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class ObsSelfRotation : MonoBehaviour
{
    [Observable(numStackedObservations: 3)]
    Vector2 Rotation 
    {
        get
        {
            Vector2 _result = new Vector2(gameObject.transform.rotation.z, gameObject.transform.rotation.x);
            return _result;
        }
    }
}
