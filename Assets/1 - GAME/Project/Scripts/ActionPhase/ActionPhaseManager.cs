using UnityEngine;
using UnityEngine.Events;

using System.Collections.Generic;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ActionPhaseManager : SerializedMonoBehaviour
    {
        [BoxGroup("References")]
        public Transform crabesParent = default;
        [BoxGroup("References")]
        public ActionPhase actionPhase = default;

        [BoxGroup("Events")]
        public UnityEvent 
            onStart = new UnityEvent(),
            onExit = new UnityEvent();        


        [FoldoutGroup("Debugs")]
        public List<VagueData> vagues = new List<VagueData>();
        [ReadOnly]
        public LeaderCrabData leaderCrabDataChoosen = default;


        private void Start()
        {
            InitializeActionPhase();
        }

        public void InitializeActionPhase()
        {
            actionPhase.StartPhase(this);

        }
    }
}
