using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AgentBumper : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 1;
    [SerializeField] private Rigidbody parentRigidbody;

    private void Start()
    {
        parentRigidbody = transform.parent.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            float forceAmount = CalculateForceAmount();
            otherRigidbody.AddForce(transform.forward * forceAmount * forceMultiplier, ForceMode.Impulse);
        }
    }

    private float CalculateForceAmount()
    {
        float velocity = parentRigidbody.velocity.magnitude;
        float direction = Vector3.Dot(transform.forward, parentRigidbody.velocity.normalized);
        return velocity * direction;
    }

    public void ChangeForceMultiplier(float input)
    {
        forceMultiplier = input;
    }
}
