using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QRTools.UI;

namespace CRABMAGA
{
    public class ChoosingLeaderMenu : UIMenu
    {
        public Vague vague = default;
        public ActionPhaseManager actionPhaseManager = default;
        public Phase PhaseChooseUnit = default;

        public override void Hide()
        {
            base.Hide();
        }

        public override void Init()
        {
            base.Init();
            PhaseChooseUnit.onPhaseEnd.AddListener(ValidateUnit);
        }

        public override void Show()
        {
            base.Show();
        }

        public void ValidateUnit()
        {
            vague.AddUnitsToInvoke(new UnitToInvoke(actionPhaseManager.leaderCrabDataChoosen, 5, Vector3.zero));
        }
    }
}
