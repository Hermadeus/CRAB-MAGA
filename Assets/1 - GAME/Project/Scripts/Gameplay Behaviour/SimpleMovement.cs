using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

using DG.Tweening;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Behaviours/Simple Movement")]
    public class SimpleMovement : ScriptableWithDescription, IMovementBehaviour
    {
        [BoxGroup("Movement")]
        public float speed = 5f;

        [BoxGroup("SideMovement")]
        public float sideMovementDuration = 1f;
        [BoxGroup("SideMovement")]
        public Ease easingMovement = Ease.InBounce;

        public void Move(Crab crab)
        {
            crab.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }

        public void TurnRight(Crab crab)
        {
            if (crab.currentLine + 1 > crab.lineEditor.lines.Count - 1)
                return;
            else
                crab.currentLine += 1;

            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine), sideMovementDuration).SetEase(easingMovement);
        }

        public void TurnLeft(Crab crab)
        {
            if (crab.currentLine - 1 < 0)
                return;
            else
                crab.currentLine -= 1;

            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine), sideMovementDuration).SetEase(easingMovement);
        }
    }
}
