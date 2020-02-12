using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Crabs/General Crab Data")]
    public class GeneralCrabData : ScriptableWithDescription
    {
        [Title("GENERAL")]
        [BoxGroup("Généralité")]
        public StringLanguage crabName;
        [BoxGroup("Généralité"), PreviewField]
        public Sprite icon = default;
        [BoxGroup("Généralité")]
        public TextLanguage crabDescription;

        [BoxGroup("Prefabs")]
        public GeneralCrab generalCrabPrefab = default;
        [BoxGroup("Prefabs")]
        public CrabFollower crabFollowerPrefab = default;

        [BoxGroup("Properties")]
        public int followersMax = 10;

        [BoxGroup("Détails")]
        public bool isLock = false;
    }
}
