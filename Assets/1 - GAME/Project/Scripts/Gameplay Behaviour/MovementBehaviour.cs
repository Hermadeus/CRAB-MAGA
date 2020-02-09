using UnityEngine;

using DG.Tweening;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public abstract class MovementBehaviour : ScriptableWithDescription, IMovementBehaviour
    {
        [BoxGroup("Movement"), Tooltip("Vitesse de l'entité")]
        public float speed = 1f;

        [BoxGroup("SideMovement"), Tooltip("Vitesse pour changer de line")]
        public float sideMovementDuration = 1.5f;
        [BoxGroup("SideMovement"), Tooltip("Forme de la courbe que prend l'entité pour changer de line")]
        public Ease easingMovement = Ease.InOutQuad;

        /// <summary>
        /// Movement 
        /// </summary>
        /// <param name="crab"></param>
        public virtual void Move(Crab crab)
        {
            crab.transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }

        /// <summary>
        /// Mouvement pour tourner vers la droite
        /// </summary>
        /// <param name="crab"></param>
        public virtual void TurnRight(Crab crab)
        {
            if (crab.currentLine + 1 > crab.lineEditor.lines.Count - 1)
                return;
            else
                crab.currentLine += 1;
        }

        /// <summary>
        /// Mouvement pour tourner vers la gauche
        /// </summary>
        /// <param name="crab"></param>
        public virtual void TurnLeft(Crab crab)
        {
            if (crab.currentLine - 1 < 0)
                return;
            else
                crab.currentLine -= 1;
        }
    }
}
