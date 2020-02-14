using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QRTools.UI;
using QRTools.Inputs;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class UnitWheel : UIElement
    {
        public List<UIWheelPart> wheelParts = new List<UIWheelPart>();

        public UIWheelPart selectedPart = default;

        [ReadOnly] public LineEditor lineEditor = default;
        public Vague vague;

        public override void Init()
        {
        }

        public override void Show()
        {
        }

        public override void Hide()
        {
            //selectedPart = null;
        }

        public void FollowFinger(TouchInput input)
        {
            rectTransform.anchoredPosition = input.InputEnterPosition;
        }

        public void ActivateWheelPart(UIWheelPart part)
        {
            DesactiveAllWheelPart();
            selectedPart = part;
            part.IsSelect = true;
        }

        public void DesactiveAllWheelPart()
        {
            for (int i = 0; i < wheelParts.Count; i++)
                wheelParts[i].IsSelect = false;
        }

        public void Invocation()
        {
            if(selectedPart != null)
            {
                vague.AddUnitsToInvoke(new UnitToInvoke(
                    selectedPart.leaderCrabData,
                    selectedPart.leaderCrabData.followersMax,
                    new Vector3(lineEditor.GetLinePosition(transform.position), 0, 0)
                    ));
            }
        }
    }
}