using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    public class Flock : MonoBehaviour
    {
        public FlockAgent agentPrefab;
        List<FlockAgent> flockAgents = new List<FlockAgent>();
        public FlockBehaviour behaviour;

        [Range(10, 20)]
        public int startingCount = 15;
        const float AgentDensity = 0.08f;

        [Range(1f, 100f)]
        public float driveFactor = 10f;
        [Range(1f, 100f)]
        public float maxSpeed = 5f;
        [Range(1f, 10f)]
        public float neightborRadius = .5f;
        [Range(0f, 1f)]
        public float avoidanceRadiusMultiplier = .5f;

        float squareMaxSpeed;
        float squareNeightborRadius;
        float squareAvoidanceRadius;
        public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

        void Start()
        {
            squareMaxSpeed = maxSpeed * maxSpeed;
            squareNeightborRadius = neightborRadius * neightborRadius;
            squareAvoidanceRadius = squareNeightborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

            for (int i = 0; i < startingCount; i++)
            {
                FlockAgent newAgent = Instantiate(agentPrefab, Random.insideUnitSphere * startingCount * AgentDensity, Quaternion.Euler(Vector3.forward * Random.Range(0,360)), transform);
                flockAgents.Add(newAgent);
            }
        }
    }
}
