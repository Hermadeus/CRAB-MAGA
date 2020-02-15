using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QRTools.UI;
using QRTools.Variables;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class ChoosingLeaderMenu : UIMenu
    {
        [BoxGroup("Leader Menu")]
        public Vague vague = default;
        [BoxGroup("Leader Menu")]
        public ActionPhaseManager actionPhaseManager = default;

        public UnitToInvoke leaderToInvoke;

        public override void Hide()
        {
            base.Hide();
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Show()
        {
            base.Show();
        }

        public void InvokeLeader()
        {
            if (leaderToInvoke == null) return;

            vague.AddUnitsToInvoke(leaderToInvoke);
            vague.Raise();
        }

        public void AddLeader()
        {
            if (actionPhaseManager.leaderCrabDataChoosen == null)
                return;

            leaderToInvoke = new UnitToInvoke(actionPhaseManager.leaderCrabDataChoosen, actionPhaseManager.leaderCrabDataChoosen.followersMax, new Vector3(0, 0, 0));
        }
    }
}
