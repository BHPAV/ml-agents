using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    
    HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent();
    }

    public void Invoke(AgentBus _agentBus)
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent(_agentBus);
    }

    public void Register(GameEventListener gameEventListener) => _listeners.Add(gameEventListener);
    public void Deregister(GameEventListener gameEventListener) => _listeners.Remove(gameEventListener);

}


[CreateAssetMenu(menuName = "Agent Event", fileName = "New Agent Event")]
public class AgentEvent : ScriptableObject
{
    
    HashSet<AgentEventListener> _listeners = new HashSet<AgentEventListener>();

    public void Invoke()
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent();
    }

    
    public void Invoke(AgentBus _agentBus)
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent(_agentBus);
    }

    
public void Register(AgentEventListener gameEventListener) => _listeners.Add(gameEventListener);
public void Deregister(AgentEventListener gameEventListener) => _listeners.Remove(gameEventListener);

}



