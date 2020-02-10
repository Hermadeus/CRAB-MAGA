using UnityEngine;

using DG.Tweening;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Behaviours/Simple Movement")]
    public class SimpleMovement : MovementBehaviour
    {
        public override void Move(Crab crab)
        {
            base.Move(crab);
        }

        public override void TurnRight(Crab crab)
        {
            base.TurnRight(crab);
            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine), sideMovementDuration.Value).SetEase(easingMovement.Value);
        }

        public override void TurnLeft(Crab crab)
        {
            base.TurnLeft(crab);
            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine), sideMovementDuration.Value).SetEase(easingMovement.Value);
        }
    }
}
