using System.Collections.Generic;

namespace CRABMAGA
{
    /// <summary>
    /// Pour le déplacement
    /// </summary>
    public interface IMovementBehaviour
    {
        void Move(Crab crab);
        void TurnRight(Crab crab);
        void TurnLeft(Crab crab);
    }

    /// <summary>
    /// Si l'entité doit suivre une autre
    /// </summary>
    /// <param name="crab"></param>
    public delegate void TurningMovement(Crab crab);
    public interface IFollowMovementBehaviour
    {
        TurningMovement TurningMovement { get; set; }
        Queue<float> NextMovementPosition { get; set; }
        Queue<TurningMovement> NextMovementAction { get; set; }
        /// <summary>
        /// précision de la position où le crabe tourne
        /// </summary>
        float Thickness { get; set; }

        void AddTurningActionRight();
        void AddTurningActionLeft();
    }

    /// <summary>
    /// Pour les généraux
    /// </summary>
    public interface IGeneralCrab
    {

    }
}
