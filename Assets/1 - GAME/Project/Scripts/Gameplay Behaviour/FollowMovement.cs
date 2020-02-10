using UnityEngine;
using Random = UnityEngine.Random;

using System.Linq;

using Sirenix.OdinInspector;

using DG.Tweening;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Behaviours/Follow Movement")]
    public class FollowMovement : MovementBehaviour
    {
        [BoxGroup("SideMovement"), MinMaxSlider(-.5f, .5f), Tooltip("Sensibilité pour le crabe à tourner")]
        public Vector2 sideMovementThickness = new Vector2(-.05f, .2f);

        [BoxGroup("SideMovement"), Range(0.01f, 10f),Tooltip("Sensibilité pour le crabe à se repositionner")]
        public float sideMovementReplacementThickness = 2f;

        public override void Move(Crab crab)
        {
            IFollowMovementBehaviour cf = crab as CrabFollower;

            crab.transform.position += new Vector3(Mathf.Sin(.1f * Time.deltaTime), 0, crab.Speed) * Time.deltaTime;

            if (cf.NextMovementPosition?.Count > 0)
                if (crab.transform.position.z > cf.NextMovementPosition.ElementAt(0) - cf.Thickness)
                {
                    cf.NextMovementPosition.Dequeue();
                    cf.NextMovementAction?.Dequeue().Invoke(crab);
                }
        }

        public override void TurnRight(Crab crab)
        {
            base.TurnRight(crab);
            crab.transform.DOMoveX(
                crab.lineEditor.GoToLine(crab.currentLine) + (Random.insideUnitCircle.x / sideMovementReplacementThickness),
                sideMovementDuration.Value).SetEase(easingMovement.Value);
        }

        public override void TurnLeft(Crab crab)
        {
            base.TurnLeft(crab);
            crab.transform.DOMoveX(
                crab.lineEditor.GoToLine(crab.currentLine) + (Random.insideUnitCircle.x / sideMovementReplacementThickness),
                sideMovementDuration.Value).SetEase(easingMovement.Value);
        }

        public void AddActionMove(Crab generalCrab, IFollowMovementBehaviour crab, TurningMovement action)
        {
            //Ajout des éléments au dictionaire
            crab.NextMovementPosition.Enqueue(generalCrab.transform.position.z);
            
            //Ajout du dictionnaire à la queue
            crab.NextMovementAction.Enqueue(action);
        }        
    }
}
