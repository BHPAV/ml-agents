using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Events/Agent Event", fileName = "New Agent Event")]
public class AgentEvent : ScriptableObject
{
    
    HashSet<AgentEventListener> _listeners = new HashSet<AgentEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent();
    }

    public void Invoke(AgentCore _agent)
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent(_agent);
    }

    
public void Register(AgentEventListener gameEventListener) => _listeners.Add(gameEventListener);
public void Deregister(AgentEventListener gameEventListener) => _listeners.Remove(gameEventListener);

}
