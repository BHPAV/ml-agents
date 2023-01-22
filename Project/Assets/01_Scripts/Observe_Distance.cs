using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Sensors.Reflection;

public class Observe_Distance : MonoBehaviour
{

    [SerializeField] private GameObject target;
    [SerializeField] private float distance;
    [SerializeField] private bool drawGizmos;

    [Observable(numStackedObservations: 3)]
    float Distance
    {
        get
        {
            return TargetDistance();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float TargetDistance()
    {
        distance = Vector3.Distance(target.transform.position, this.transform.position);   
        return distance;
    }

    void OnDrawGizmosSelected() 
    {
        if(drawGizmos)
        {
            
        } 
    }




}
