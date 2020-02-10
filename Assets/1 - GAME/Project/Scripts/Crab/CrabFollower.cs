using System.Collections.Generic;

using UnityEngine;

namespace CRABMAGA
{
    public class CrabFollower : Crab, IFollowMovementBehaviour
    {
        public GeneralCrab generalCrab = default;

        [HideInInspector]
        public Queue<float> nextMovementPosition = new Queue<float>();
        [HideInInspector]
        public Queue<TurningMovement> nextMovementAction = new Queue<TurningMovement>();
                
        TurningMovement IFollowMovementBehaviour.TurningMovement { get; set; }
        Queue<float> IFollowMovementBehaviour.NextMovementPosition
        { get => nextMovementPosition; set => nextMovementPosition = value; }
        Queue<TurningMovement> IFollowMovementBehaviour.NextMovementAction
        { get => nextMovementAction; set => nextMovementAction = value; }
        public float Thickness { get; set; }

        protected override void Init()
        {
            currentLine = lineEditor.GetLine(generalCrab.transform.position);
            SetSpeed("normal");
        }

        protected override void Execute()
        {
            base.Execute();
        }

        public void AddTurningActionRight()
        {
            FollowMovement fm = movementBehaviour as FollowMovement;
            fm.AddActionMove(generalCrab, this, fm.TurnRight);
        }

        public void AddTurningActionLeft()
        {
            FollowMovement fm = movementBehaviour as FollowMovement;
            fm.AddActionMove(generalCrab, this, fm.TurnLeft);
        }
    }
}
