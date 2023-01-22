using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventManagementSystem
{
    public static CustomUnityEvent<T> CreateEvent<T>()
    {
        return new CustomUnityEvent<T>();
    }
}


[System.Serializable]
public class CustomUnityEvent<T> : UnityEvent<T> {}




public class GameEventListener : MonoBehaviour
{
    
    [SerializeField] public GameEvent _gameEvent;
    [SerializeField] public UnityEvent _unityEvent;

    public AgentBusEvent Response;

    void Awake() => _gameEvent.Register(this);
    void OnAwake() => _gameEvent.Deregister(this);
      
    public void RaiseEvent() => _unityEvent.Invoke();
    public void RaiseEvent(AgentBus _agent){ Response.Invoke(_agent); }

    //public void RaiseEvent(float _float){ RewardResponse.Invoke(_float); }
}















