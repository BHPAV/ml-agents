using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


using Sirenix.OdinInspector;


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
    [Title("Triggering Event")]
    [SerializeField] public GameEvent _gameEvent;
    
    [Title("Response Events")]
    [FoldoutGroup("Response Events")]
    [SerializeField] public UnityEvent _unityEvent;

    void Awake() => _gameEvent.Register(this);
    void OnAwake() => _gameEvent.Deregister(this);
      
    public void RaiseEvent() => _unityEvent.Invoke();
}


public class GameEventListener<T> : GameEventListener where T : class
{
    public Action<T> OnEventInvoked;

    public void RaiseEvent(T data)
    {
        OnEventInvoked?.Invoke(data);
    }
}















