using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA {

    /// <summary>
    /// Interface qui s'occupe d'instancier n'importe quel type d'unité
    /// </summary>
    public interface ICrabFactory
    {
        Crab InstantiateCrab(Crab crab, Vector3 position, int? quantite, Transform parent);
        Crab[] InstantiateCrabs(Crab crab, Vector3 position, int? quantite, Transform parent);
    }

    public interface ICrabUnitFactory
    {
        CrabsUnit InstantiateCrabsUnit(Crab general, Crab follower, int quantiteFollower, Vector3 position);
    }
}
