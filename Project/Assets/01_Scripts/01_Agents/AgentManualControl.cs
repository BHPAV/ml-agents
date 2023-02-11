using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Policies;

public class AgentManualControl : MonoBehaviour
{

    public bool ManualControl;
    private int AIDecisionSpeed;
    private BehaviorParameters  AIBehavior;
    private DecisionRequester decisionRequester;

    // Start is called before the first frame update
    void Start()
    {
        AIBehavior = GetComponent<BehaviorParameters>();
        decisionRequester = GetComponent<DecisionRequester>();
        AIDecisionSpeed = decisionRequester.DecisionPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        //ControlCheck();
    }


    public void ControlCheck()
    {
        if (ManualControl)
        {
            AIBehavior.BehaviorType = Unity.MLAgents.Policies.BehaviorType.HeuristicOnly;
            decisionRequester.DecisionPeriod = 1;
            
        }
        else
        {
            AIBehavior.BehaviorType = Unity.MLAgents.Policies.BehaviorType.InferenceOnly;
            decisionRequester.DecisionPeriod = AIDecisionSpeed;
        }
    }


    public void ChangeState()
    {
        ManualControl = !ManualControl;
        ControlCheck();
    }





    
}
