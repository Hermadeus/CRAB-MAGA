using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QRTools.UI;

namespace CRABMAGA
{
    public class ChoosingLeaderButton : UIButton
    {
        public LeaderCrabData LeaderCrabData = default;
        public ActionPhaseManager actionPhaseManager = default;

        public override void Init()
        {
            base.Init();
            title.text = LeaderCrabData.crabName.GetCurrentVersion(LanguageEnum.Instance);
            Icon.sprite = LeaderCrabData.icon;

            OnClick.AddListener(ChooseLeader);
        }

        public override void Hide()
        {
            base.Hide();
        }

        public override void Show()
        {
            base.Show();
            title.text = LeaderCrabData.crabName.GetCurrentVersion(LanguageEnum.Instance);
        }

        void ChooseLeader()
        {
            actionPhaseManager.leaderCrabDataChoosen = LeaderCrabData;
        }
    }
}