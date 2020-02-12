using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/Leader Crab Data")]
    public class LeaderCrabData : ScriptableWithDescription
    {
        [Title("GENERAL")]
        [BoxGroup("Généralité")]
        public StringLanguage crabName;
        [BoxGroup("Généralité"), PreviewField]
        public Sprite icon = default;
        [BoxGroup("Généralité")]
        public TextLanguage crabDescription;

        [BoxGroup("Prefabs")]
        public LeaderCrab leaderCrabPrefab = default;
        [BoxGroup("Prefabs")]
        public CrabFollower crabFollowerPrefab = default;

        [BoxGroup("Properties")]
        public int followersMax = 10;

        [BoxGroup("Détails")]
        public bool isLock = false;
    }
}
