using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Reward Event", fileName = "New Reward Event")]
public class RewardEvent : ScriptableObject
{
    
    HashSet<RewardListener> _listeners = new HashSet<RewardListener>();

    public void Invoke(AgentBus _agentBus)
    {
        foreach (var globalEventListener in _listeners)
            globalEventListener.RaiseEvent(_agentBus);
    }

    public void Register(RewardListener rewardListener) => _listeners.Add(rewardListener);
    public void Deregister(RewardListener rewardListener) => _listeners.Remove(rewardListener);

}

