using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Sensors.Reflection;

public class Sensor_Targeter : MonoBehaviour
{


    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 tPosistion;
    [SerializeField] private Vector3 tDirection;



    //Specific Observations for Location of the Car - Speed Variable
    [Observable(numStackedObservations: 9)]
    Vector3 Position
    {
        get
        {
            return TargetMovement();
        }
    }

    //Specific Observations for Rotation of the Car
    [Observable(numStackedObservations: 9)]
    Vector3 Direction
    {
        get
        {
            return TargetLocation();
        }
    }


    void Update()
    {
        tPosistion = Position;
        tDirection = Direction;
    }




    public Vector3 TargetMovement()
    {
        //Provides 1 Vector 3 observations.
        //If target is null - Provide zero value observations
        if(target != null)
            {
                // Target position in agent frame
                return this.transform.InverseTransformPoint(target.transform.position); // vec 3
            }
            else
            {
                return this.transform.InverseTransformPoint(transform.position); // vec 33
            }
    }

    public Vector3 TargetLocation()
    {
        //Provides 1 Vector 3 observations.
        //If target is null - Provide zero value observations
        Vector3 _result = Vector3.zero;

        if(target != null)
            {
                // Target Direction in agent frame
                _result = this.transform.InverseTransformDirection(FindDirection(target));
                _result = _result.normalized;
                return _result;
            }
            else
            {
                return _result; // vec 3
            }
    }





    // Tools and Math functions -------------------------------------------
    public Vector3 FindDirection(GameObject _target)
    {
        Vector3 dir = (this.transform.position - _target.transform.position).normalized;
        return dir;
    }

    public float FindDistance(GameObject _target)
    {
        float dist = Vector3.Distance(_target.transform.position, transform.position);
        return dist;
    }
}
