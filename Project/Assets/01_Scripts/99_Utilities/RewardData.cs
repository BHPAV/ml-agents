using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(menuName = "Reward Data", fileName = "New Reward Data")]
public class RewardData : ScriptableObject
{
    
    [SerializeField] private string rewardName;
    [SerializeField] private float rewardWeight;
    [SerializeField] private float rewardValue;

    [SerializeField] private bool isPositive;
    [SerializeField] private bool isGameEnding;

    [SerializeField] GameEvent triggeringEvent;
    
    public void IssueReward(AgentBus _agent)
    {
        float _result = 0.0f;

        if(isPositive)
            _result = rewardValue * rewardWeight;
        else
            _result = -rewardValue * rewardWeight;


        _agent.ApplyReward(_result);

        if(isGameEnding)
        {
            
            _agent.RequestEpisodeEnd();
        }
    }




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
