using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors.Reflection;

public class ObsTargetDistance : MonoBehaviour
{

    public AgentBus agentBus;
    public Transform target;   

    public void AddObservations()
    {
        //agentBus.AddVectorObs(Vector3.Distance(ball.position, transform.position));
        //agentBus.AddVectorObs(Vector3.Distance(ball.position, targetArea.position));
    }
    
    [Observable(numStackedObservations: 3)]
    float TargetDistance
    {
        get
        {
            float _dist = Vector3.Distance(target.position, transform.position);
            return _dist;
        }
    }

}
