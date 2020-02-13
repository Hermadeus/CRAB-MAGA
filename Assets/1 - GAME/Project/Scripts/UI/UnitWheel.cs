using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using QRTools.UI;
using QRTools.Inputs;

namespace CRABMAGA
{
    public class UnitWheel : UIElement
    {
        public override void Init()
        {
        }

        public override void Show()
        {
        }

        public override void Hide()
        {
        }

        public void FollowFinger(TouchInput input)
        {
            rectTransform.anchoredPosition = input.InputEnterPosition;
            Debug.Log(input.InputEnterPosition);
        }
    }
}