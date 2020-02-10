using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Factory/Crab Follower Factory")]
    public class CrabFollowerFactory : ScriptableWithDescription, ICrabFactory
    {
        public Crab crabPrefab = default;

        public Crab[] InstantiateCrabs(Crab crab, Vector3 position, int? quantite, Transform parent)
        {
            List<Crab> crabs = new List<Crab>();

            for (int i = 0; i < quantite; i++)
            {
                Crab c = Instantiate(
                    crabPrefab,
                    position + new Vector3(Random.Range(-.5f, .5f), 0, Random.Range(-.6f, -2f)),
                    Quaternion.identity,
                    parent
                    );
                crabs.Add(c);
            }

            return crabs.ToArray();
        }

        public Crab InstantiateCrab(Crab crab, Vector3 position, int? quantite, Transform parent)
        {
            throw new System.NotImplementedException();
        }
    }
}
