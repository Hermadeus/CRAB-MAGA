using UnityEngine;
using UnityEngine.Events;

using System.Collections.Generic;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ActionPhaseManager : SerializedMonoBehaviour
    {
        public UnityEvent onStart = new UnityEvent();
        public UnityEvent onExit = new UnityEvent();        

        public ActionPhase actionPhase = default;

        public List<VagueData> vagues = new List<VagueData>();

        public Transform crabesParent = default;

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
