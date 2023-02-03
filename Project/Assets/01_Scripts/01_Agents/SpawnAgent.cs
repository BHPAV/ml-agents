using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Policies;


    public class SpawnAgent : MonoBehaviour
    {

        [SerializeField] private GameObject agentPrefab;

        private AgentCore agent;
        private GameObject car;


        private bool ManualControl;
        private int AIDecisionSpeed;
        private BehaviorParameters  AIBehavior;
        private DecisionRequester decisionRequester;

        private bool Spawned;


        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<AgentCore>();

            CreateAgent();
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        public void CreateAgent()
        {
            if(!Spawned)
            {


                //Create the model for the Agent to play with
                car = Instantiate(agentPrefab,transform);
                car.transform.parent = transform;
                CarDriver carDriver = car.GetComponent<CarDriver>();

                //Update the RigidBody
                Rigidbody _rb = GetComponent<Rigidbody>();
                carDriver.SetRigidbody(_rb);

                //Give it the level specific attributes
                agent.SetCarDriver(carDriver);
                //agent.transforms = carSpawns;
                //agent.ground = ground;
                //agent.area = area;
                //agent._actionReceived = _actionReceived;
                //agent._crashedEvent = _crashedEvent;
                //agent._EpisodeRestart = _EpisodeRestart;
                //agent.goal = goal;
                //agent.goalArea = goalArea;
                //agent.block = block;
                //agent.m_BlockRb = block.GetComponent<Rigidbody>();

                //SpawnPointManager spawnPointManager = car.GetComponent<SpawnPointManager>();
                //spawnPointManager.transforms = ballSpawns;

                //Manual Control Variables
                /*
                AIBehavior = car.GetComponent<BehaviorParameters>();
                decisionRequester = car.GetComponent<DecisionRequester>();
                AIDecisionSpeed = decisionRequester.DecisionPeriod;
                */

                //Set to active.
                car.SetActive(true);

                //Disable Button
                Spawned = true;
            }    
        }

        public void UpdateAgent(GameObject _agentPrefab)
        {
            if(_agentPrefab != null)
                agentPrefab = _agentPrefab;
        }

        public void ControlCheck()
        {
            /*
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
            */
        }


        public void ChangeState()
        {
            /*
            ManualControl = !ManualControl;
            ControlCheck();
            */
        }
    }


