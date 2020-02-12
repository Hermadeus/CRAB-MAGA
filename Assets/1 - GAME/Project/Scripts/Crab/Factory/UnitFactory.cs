using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Factory/Crab Unity Factory")]
    public class UnitFactory : ScriptableWithDescription, ICrabFactory
    {
        public CrabsUnit CrabUnitPrefab = default;

        /// <summary>
        /// Permet d'instantier une unité de crabe complete
        /// </summary>
        public CrabsUnit InstantiateCrabsUnit(GeneralCrabData general, int quantiteFollower, Vector3 position)
        {
            CrabsUnit newUnit = Instantiate(CrabUnitPrefab, position, Quaternion.identity);
            newUnit.generalCrab = InstantiateGeneralCrab(general, newUnit, position);
            newUnit.generalCrab.transform.parent = newUnit.transform;

            if (quantiteFollower > 0)
            {
                newUnit.followers = InstantiateFollowers(newUnit.generalCrab.generalCrabData, quantiteFollower, position, newUnit.transform);
                for (int i = 0; i < newUnit.followers.Count; i++)
                    newUnit.followers[i].generalCrab = newUnit.generalCrab;
            }

            newUnit.name = "Crab Unit : " + general.crabName.GetCurrentVersion(LanguageEnum.Instance);

            return newUnit;
        }

        /// <summary>
        /// Permet d'instantier un general crab
        /// </summary>
        public GeneralCrab InstantiateGeneralCrab(GeneralCrabData general, CrabsUnit unit, Vector3 position)
        {
            GeneralCrab newGeneralCrab = Instantiate(general.generalCrabPrefab as GeneralCrab, position, Quaternion.identity);

            return newGeneralCrab;
        }

        /// <summary>
        /// Permet d'instancier des followers
        /// </summary>
        public List<CrabFollower> InstantiateFollowers(GeneralCrabData general, int quantiteFollower, Vector3 position, Transform parent)
        {
            List<CrabFollower> newCrabsFollower = new List<CrabFollower>();
            for (int i = 0; i < quantiteFollower; i++)
            {
                newCrabsFollower.Add(Instantiate(
                    general.crabFollowerPrefab,
                    position + new Vector3(Random.Range(-.5f, .5f), 0, Random.Range(-.6f, -2f)),
                    Quaternion.identity,
                    parent
                    ));
            }
            return newCrabsFollower;
        }

    }
}
