using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [RequireComponent(typeof(Collider))]
    public class FlockAgent : MonoBehaviour
    {
        Collider agentCollider;
        public Collider AgentCollider
        {
            get { return agentCollider; }
        }

        void Start()
        {
            agentCollider = GetComponent<Collider>();
        }

        public void Move(Vector3 velocity)
        {
            transform.up = velocity;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
