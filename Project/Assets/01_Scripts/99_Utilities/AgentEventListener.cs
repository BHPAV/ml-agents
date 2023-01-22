using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

[System.Serializable]
public class AgentBusEvent : UnityEvent<AgentBus> {}

public class AgentEventListener : MonoBehaviour
{

    [SerializeField] public AgentEvent _gameEvent;
    [SerializeField] public UnityEvent _unityEvent;

    public AgentBusEvent Response;

    void Awake() => _gameEvent.Register(this);
    void OnAwake() => _gameEvent.Deregister(this);
      
    public void RaiseEvent() => _unityEvent.Invoke();  
    public void RaiseEvent(AgentBus _agent){ Response.Invoke(_agent); }

}


