using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Action Phase/Action Phase")]
    public class ActionPhase : ScriptableWithDescription, IActionPhase
    {
        public List<IPhase> phases = new List<IPhase>();

        public ActionPhaseManager actionPhaseManager { get; set; }

        public void StartPhase(ActionPhaseManager actionPhaseManager)
        {
            phases[0]?.OnBegin(this);
        }

        public void EndPhase(ActionPhaseManager actionPhaseManager)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
