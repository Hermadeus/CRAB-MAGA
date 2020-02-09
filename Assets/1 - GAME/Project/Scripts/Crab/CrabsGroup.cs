using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class CrabsGroup : MonoBehaviour
    {
        [Required]
        public Crab miniCrabPrefab = default;

        public Transform miniCrabParent;

        public GeneralCrab leader = default;

        public int initCrab;

        void Start()
        {
            for (int i = 0; i < initCrab; i++)
            {
                Crab miniCrab = Instantiate(
                    miniCrabPrefab,
                    leader.transform.position + new Vector3(Random.Range(-.5f, .5f), 0, Random.Range(-.6f, -2f)),
                    Quaternion.identity,
                    miniCrabParent
                    );
            }
        }
    }
}
