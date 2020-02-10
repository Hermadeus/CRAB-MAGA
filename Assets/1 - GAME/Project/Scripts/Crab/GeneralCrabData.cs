using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/General Crab Data")]
    public class GeneralCrabData : ScriptableWithDescription
    {
        public Crab generalCrabPrefab = default;
        public Crab crabFollowerPrefab = default;

        public int followersMax = 10;
    }
}
