using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
		public int rotateSpeed=90;
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
		{
			if (target != null)
				agent.SetDestination (target.position);

			//transform.Translate(Vector3.forward * Time.deltaTime);
			//transform.Translate(Vector3.up * Time.deltaTime, Space.World);


			if (agent.remainingDistance > agent.stoppingDistance) {
				character.Move (agent.desiredVelocity, false, false);
				transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
			} else {
				character.Move (Vector3.zero, false, false);
				transform.Rotate (0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);
			
			}
		}


      public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
