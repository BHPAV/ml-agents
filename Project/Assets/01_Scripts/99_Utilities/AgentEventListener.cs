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
    [SerializeField] public AgentEvent _gameEvent;

    [Title("Response Events")]
    [FoldoutGroup("Response Events")]
    [SerializeField] public UnityEvent _unityEvent;

    [FoldoutGroup("Response Events")]
    [SerializeField] public AgentCoreEvent AgentResponse;


    void Awake() => _gameEvent.Register(this);
    void OnAwake() => _gameEvent.Deregister(this);
      
    public void RaiseEvent() => _unityEvent.Invoke();  
    public void RaiseEvent(AgentCore _agent){ AgentResponse.Invoke(_agent); }

}


