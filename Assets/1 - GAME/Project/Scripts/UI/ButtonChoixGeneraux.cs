using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CRABMAGA
{
    public class ButtonChoixGeneraux : MonoBehaviour
    {
        public Button button = default; 

        public GeneralCrabData generalCrabData = default;

        public Image icon = default;
        public TextMeshProUGUI generalName = default;

        public void InitButton()
        {
            icon.sprite = generalCrabData.icon;

        }
    }
}
