using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Pushball
{


    public class Controller_Pushball : MonoBehaviour
    {
        [HideInInspector]
        public EvnController_Pushball envController;

        public GameObject purpleGoal;
        public GameObject blueGoal;
        Collider purpleGoalCollider;
        Collider blueGoalCollider;

        void Start()
        {
            envController = GetComponentInParent<EvnController_Pushball>();
            purpleGoalCollider = purpleGoal.GetComponent<Collider>();
            blueGoalCollider = blueGoal.GetComponent<Collider>();
        }

        /// <summary>
        /// Detects whether the ball lands in the blue, purple, or out of bounds area
        /// </summary>
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("boundary"))
            {
                // ball went out of bounds
                envController.ResolveEvent(Event.HitOutOfBounds);
            }
            else if (other.gameObject.CompareTag("blueBoundary"))
            {
                // ball hit into blue side
                envController.ResolveEvent(Event.HitIntoBlueArea);
            }
            else if (other.gameObject.CompareTag("purpleBoundary"))
            {
                // ball hit into purple side
                envController.ResolveEvent(Event.HitIntoPurpleArea);
            }
            else if (other.gameObject.CompareTag("purpleGoal"))
            {
                // ball hit purple goal (blue side court)
                envController.ResolveEvent(Event.HitPurpleGoal);
            }
            else if (other.gameObject.CompareTag("blueGoal"))
            {
                // ball hit blue goal (purple side court)
                envController.ResolveEvent(Event.HitBlueGoal);
            }

        }
    
    }


}
