using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA {

    /// <summary>
    /// Interface qui s'occupe d'instancier n'importe quel type d'unité
    /// </summary>
    public interface ICrabFactory
    {
        CrabsUnit InstantiateCrabsUnit(LeaderCrabData general, int quantiteFollower, Vector3 position);
        LeaderCrab InstantiateGeneralCrab(LeaderCrabData general, CrabsUnit unit, Vector3 position);
        List<CrabFollower> InstantiateFollowers(LeaderCrabData general, int quantiteFollower, Vector3 position, Transform parent);
    }
}
