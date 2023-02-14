using UnityEngine;

public class VehicleInstantiation : MonoBehaviour
{


    public VehicleData vehicleData;




    private void Start()
    {
        CreateVehicle();
    }





    private void CreateVehicle()
    {
        if (vehicleData == null)
        {
            Debug.LogError("VehicleData not assigned");
            return;
        }

        GameObject body = Instantiate(vehicleData.m_Body);
        body.name = vehicleData.dataName;
        body.transform.position = transform.position;

        Rigidbody rb = body.GetComponent<Rigidbody>();
        if (rb != null)
        {
            AssignMass(rb, vehicleData.mass);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on Body object");
        }

        GameObject wheels = new GameObject("Wheels");
        wheels.transform.SetParent(body.transform);
        wheels.transform.localPosition = Vector3.zero;

        int wheelCount = 0;
        foreach (Vector3 wheelPosition in vehicleData.wheelPositions)
        {
            string wheelName = GetWheelName(wheelCount);
            GameObject wheel = Instantiate(vehicleData.m_Wheel, wheels.transform);
            wheel.name = wheelName;
            wheel.transform.localPosition = wheelPosition;

            if(wheelCount < 2)
                SetFWD(wheel);

            wheelCount++;
        }

        GameObject centerOfGravity = new GameObject("CenterOfGravity");
        centerOfGravity.transform.SetParent(body.transform);
        centerOfGravity.transform.localPosition = vehicleData.centerOfGravity;

        AssignCenterOfMass(rb, centerOfGravity.transform);
    }

    private void AssignMass(Rigidbody rb, float mass)
    {
        rb.mass = mass;
    }

    private void AssignCenterOfMass(Rigidbody rb, Transform centerOfGravity)
    {
        rb.centerOfMass = centerOfGravity.localPosition;
    }

    private string GetWheelName(int wheelCount)
    {
        string wheelName = "Wheel_";
        if (wheelCount % 2 == 0)
        {
            wheelName += "L";
        }
        else
        {
            wheelName += "R";
        }
        wheelName += (wheelCount / 2).ToString();

        return wheelName;
    }


    private void SetFWD(GameObject _wheel)
    {
        WheelControl _wheelControl = _wheel.GetComponent<WheelControl>();
        _wheelControl.canPower = true;
        _wheelControl.canSteer = true;
    }


}