using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA {
    public interface IPhase
    {
        IPhase NextPhase { get; set; }

        void OnBegin(ActionPhase actionPhase);

        void OnEnd(ActionPhase actionPhase);
    }

    public interface IActionPhase
    {
        void StartPhase(ActionPhaseManager actionPhaseManager);

        void EndPhase(ActionPhaseManager actionPhaseManager);
    }
}
