using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using Sirenix.OdinInspector;

[System.Serializable] public class AgentBusEvent : UnityEvent<AgentBus> {}

[System.Serializable] public class AgentCoreEvent : UnityEvent<AgentCore> {}

public class AgentEventListener : MonoBehaviour
{
    [Title("Triggering Event")]
    [SerializeField] public AgentEvent _agentEvent;

    [FoldoutGroup("Response Events")]
    [SerializeField] public AgentCoreEvent Response;


    void Awake() => _agentEvent.Register(this);
    void OnAwake() => _agentEvent.Deregister(this);
       
    public void RaiseEvent(AgentCore _agent){ Response.Invoke(_agent); }
}


