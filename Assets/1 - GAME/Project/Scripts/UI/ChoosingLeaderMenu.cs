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
        [BoxGroup("Leader Menu")]
        public GameEvent onVagueRaise = default;

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

        public void ValidateUnit()
        {
            AddUnit();
            vague.Raise();
        }

        public void AddUnit()
        {
            vague.AddUnitsToInvoke(new UnitToInvoke(actionPhaseManager.leaderCrabDataChoosen, actionPhaseManager.leaderCrabDataChoosen.followersMax, new Vector3(0, 0, 0)));
        }
    }
}
