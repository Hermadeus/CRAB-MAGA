using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Action Phase/Phase")]
    public class Phase : ScriptableWithDescription, IPhase
    {
        [SerializeField] private IPhase nextPhase = default;
        public IPhase NextPhase { get => nextPhase; set => nextPhase = value; }

        public UnityEvent
            onPhaseBegin = new UnityEvent(),
            onPhaseEnd = new UnityEvent();

        public void OnBegin(ActionPhase actionPhase)
        {
            onPhaseBegin.Invoke();
        }

        public void OnEnd(ActionPhase actionPhase)
        {
            onPhaseEnd.Invoke();

            nextPhase?.OnBegin(actionPhase);
        }
    }
}
