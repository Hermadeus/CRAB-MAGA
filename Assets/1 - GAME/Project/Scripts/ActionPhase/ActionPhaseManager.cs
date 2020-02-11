using UnityEngine;
using UnityEngine.Events;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ActionPhaseManager : SerializedMonoBehaviour
    {
        public UnityEvent onStart = new UnityEvent();
        public UnityEvent onExit = new UnityEvent();        

        public ActionPhase actionPhase = default;

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
