using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardListener : MonoBehaviour
{
    [SerializeField] public RewardEvent _rewardEvent;

    public AgentBusEvent Response;

    void Awake() => _rewardEvent.Register(this);
    void OnAwake() => _rewardEvent.Deregister(this);
      
    public void RaiseEvent(AgentBus _agent){ Response.Invoke(_agent); }
}
