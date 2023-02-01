using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;


[System.Serializable] public class AgentBusEvent : UnityEvent<AgentBus> {}
[System.Serializable] public class AgentCoreEvent : UnityEvent<AgentCore> {}

public class AgentEventListener : MonoBehaviour
{

    [SerializeField] public AgentEvent _gameEvent;
    [SerializeField] public UnityEvent _unityEvent;

    public AgentEvent Response;

    void Awake() => _gameEvent.Register(this);
    void OnAwake() => _gameEvent.Deregister(this);
      
    public void RaiseEvent() => _unityEvent.Invoke();  
    public void RaiseEvent(AgentCore _agent){ Response.Invoke(_agent); }

}


