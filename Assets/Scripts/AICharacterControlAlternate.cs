using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControlAlternate : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public List<Transform> positions = new List<Transform>();
        public float timer;
        public Transform pos;
        public float min;
        public float max;
        public bool countDown;
        Transform previousPos;
        public List<Transform> locations = new List<Transform>();
		public RootMotion.Demos.UserControlInteractions userControlInteractions;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

            Randomize();
            
        }


        void Update()
        {
            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

          
            if(countDown)
            {
                timer -= Time.deltaTime;
            }
            
            if(timer <= 0)
			{
				userControlInteractions.aiCanGrab = true;
                countDown = false;
                Randomize();

                
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        void Randomize()
        {
            
            int random = Random.Range(0, 3);
            pos = positions[random];
            locations.Add(positions[random]);
            positions.RemoveAt(random);
            agent.SetDestination(pos.position);
            timer = Random.Range(min, max);
            if(positions.Count == 0)
            {
                for(int i = 0; i < 4;i++)
                {
                    positions.Add(locations[i]);
                    locations.RemoveAt(i);
                }
            }
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.tag == "Position")
            {
                countDown = true;
            }
        }

        void OnTriggerStay(Collider col)
        {
            if (col.gameObject.tag == "Position")
            {
                countDown = true;
            }
        }

        void OnTriggerExit(Collider col)
        {
            if (col.gameObject.tag == "Position")
            {
                countDown = false;
            }
        }

    }
}
