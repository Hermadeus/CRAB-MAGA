using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

using Sirenix.OdinInspector;

using DG.Tweening;

using QRTools.Functions;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Behaviours/Follow Movement")]
    public class FollowMovement : MonoBehaviour, IMovementBehaviour
    {
        [BoxGroup("Movement")]
        public float speed = 5f;

        [BoxGroup("SideMovement")]
        public float sideMovementDuration = 5f;

        [BoxGroup("SideMovement")]
        public Ease easingMovement = Ease.InExpo;

        [BoxGroup("SideMovement"), MinMaxSlider(-.5f, .5f)]
        public Vector2 sideMovementThickness = new Vector2(-.05f, .2f);
        float thickness;

        public delegate void TurningMovement(Crab crab);

        [HideInInspector]
        public Queue<float> nextMovementPosition = new Queue<float>();
        [HideInInspector]
        public Queue<TurningMovement> nextMovementAction = new Queue<TurningMovement>();

        public void Start()
        {
            thickness = Random.Range(sideMovementThickness.x, sideMovementThickness.y);
        }

        public void Move(Crab crab)
        {
            crab.transform.position += new Vector3(Mathf.Sin(.1f * Time.deltaTime), 0, speed) * Time.deltaTime;

            if (nextMovementPosition?.Count > 0)
                if (crab.transform.position.z > nextMovementPosition.ElementAt(0) - thickness)
                {
                    nextMovementPosition.Dequeue();
                    nextMovementAction?.Dequeue().Invoke(crab);
                }
        }

        public void TurnRight(Crab crab)
        {
            if (crab.currentLine + 1 > crab.lineEditor.lines.Count - 1)
                return;
            else
                crab.currentLine += 1;

            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine) + (Random.insideUnitSphere.x / 2), sideMovementDuration).SetEase(easingMovement);
        }

        public void TurnLeft(Crab crab)
        {
            if (crab.currentLine - 1 < 0)
                return;
            else
                crab.currentLine -= 1;

            crab.transform.DOMoveX(crab.lineEditor.GoToLine(crab.currentLine) + (Random.insideUnitSphere.x / 2), sideMovementDuration).SetEase(easingMovement);
        }

        public void AddRightMove(Crab generalCrab)
        {
            //Ajout des éléments au dictionaire
            nextMovementPosition.Enqueue(generalCrab.transform.position.z);
            
            //Ajout du dictionnaire à la queue
            nextMovementAction.Enqueue(TurnRight);
        }

        public void AddLeftMove(Crab generalCrab)
        {
            //Ajout des éléments au dictionaire
            nextMovementPosition.Enqueue(generalCrab.transform.position.z);
            
            //Ajout du dictionnaire à la queue
            nextMovementAction.Enqueue(TurnLeft);
        }

        public void OnDisable()
        {
            nextMovementPosition.Clear();
            nextMovementAction.Clear();
        }
    }
}
