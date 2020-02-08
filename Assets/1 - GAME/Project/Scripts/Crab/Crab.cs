using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using QRTools;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class Crab : SerializedMonoBehaviour
    {
        public IMovementBehaviour movementBehaviour = default;

        public int currentLine;
        [HideInInspector] public LineEditor lineEditor;

        public Crab generalCrab = default;

        private void Start()
        {
            lineEditor = FindObjectOfType<LineEditor>();
            currentLine = lineEditor.GetLine(generalCrab.transform.position);
        }

        private void Update()
        {
            movementBehaviour.Move(this);
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                0
                );
        }

        public void AddTurningActionRight()
        {
            FollowMovement fm = movementBehaviour as FollowMovement;
            fm.AddRightMove(generalCrab);
        }

        public void AddTurningActionLeft()
        {
            FollowMovement fm = movementBehaviour as FollowMovement;
            fm.AddLeftMove(generalCrab);
        }

    }
}
