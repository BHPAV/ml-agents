using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AgentBumper : MonoBehaviour
{
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "agent" && GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            Rigidbody agentRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            agentRigidbody.AddForce(Vector3.up * 100, ForceMode.Impulse);
        }
    }
}
