using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideReward : MonoBehaviour
{



    [SerializeField] private AgentBus agent;
    [SerializeField] private string tagCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] RewardEvent _hitRewardEvent;
    void HitTag()
    {
        _hitRewardEvent.Invoke(agent);
    }

    void OnCollisionEnter(Collision col)
    {
        // Touched goal.
        if (col.gameObject.CompareTag(tagCheck))
        {
            HitTag();
        }
    }
}
