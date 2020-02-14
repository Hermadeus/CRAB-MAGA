using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using QRTools.UI;
using UnityEngine.Events;

namespace CRABMAGA
{
    public class UIWheelPart : UIElement, IUIInteractible
    {
        [SerializeField] private bool isSelect = false;
        public LeaderCrabData leaderCrabData = default;



        public bool IsSelect { 
            get
            {
                return isSelect;
            }
            set
            {
                isSelect = value;
                if (value == true)
                    Show();
                else
                    Hide();
            }
        }

        [SerializeField] private UnityEvent onClick = new UnityEvent();
        public UnityEvent OnClick { get => onClick; set => onClick = value; }

        public Image background = default;

        public override void Hide()
        {
            background.color = Color.white;
        }

        public override void Init()
        {
            background = GetComponent<Image>();
        }

        public override void Show()
        {
            background.color = Color.green;
        }
    }
}