using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDistance : MonoBehaviour
{
    
    [SerializeField] private AgentBus agent;
    [SerializeField] private GameObject _object1;
    [SerializeField] private GameObject _object2;




    public void RunReward()
    {
        //Vector3 _dist = GetDistance();
    }



    public float GetDistance()
    {
        return Vector3.Distance(_object1.transform.position, _object2.transform.position);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
