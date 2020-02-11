using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/General Crab Data")]
    public class GeneralCrabData : ScriptableWithDescription, IGeneralCrab
    {
        public string generalCrabName;

        [BoxGroup("Prefabs")]
        public GeneralCrab generalCrabPrefab = default;
        [BoxGroup("Prefabs")]
        public CrabFollower crabFollowerPrefab = default;

        public Sprite icon = default;

        [BoxGroup("Properties")]
        public int followersMax = 10;

        [BoxGroup("Détails")]
        public bool isLock = false;
    }
}
