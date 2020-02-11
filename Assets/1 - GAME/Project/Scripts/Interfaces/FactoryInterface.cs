using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA {

    /// <summary>
    /// Interface qui s'occupe d'instancier n'importe quel type d'unité
    /// </summary>
    public interface ICrabFactory
    {
        CrabsUnit InstantiateCrabsUnit(GeneralCrabData general, int quantiteFollower, Vector3 position);
        GeneralCrab InstantiateGeneralCrab(GeneralCrabData general, CrabsUnit unit, Vector3 position);
        List<CrabFollower> InstantiateFollowers(GeneralCrabData general, int quantiteFollower, Vector3 position, Transform parent);
    }
}
