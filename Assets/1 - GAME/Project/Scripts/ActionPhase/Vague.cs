using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Sirenix.OdinInspector;

namespace CRABMAGA {
    [CreateAssetMenu(menuName = "CRAB MAGA/Action Phase/Vague")]
    public class Vague : ScriptableWithDescription
    {
        public ICrabFactory unitFactory = default;

        [TableList(ShowIndexLabels = true, DrawScrollView = true)]
        public List<UnitToInvoke> unitsToInvoke = new List<UnitToInvoke>();

        public GeneralCrabData generalCrab = default;
        public ActionPhaseManagerVariable actionPhaseManager;

        public void Raise()
        {
            VagueData vaguedata = new VagueData();
            for (int i = 0; i < unitsToInvoke.Count; i++)
            {
                 CrabsUnit newUnit = unitFactory.InstantiateCrabsUnit(unitsToInvoke[i].generalCrabData,
                    unitsToInvoke[i].followerToInvoke,
                    unitsToInvoke[i].position);

                newUnit.transform.parent = actionPhaseManager.Value.crabesParent;

                vaguedata.crabUnits.Add(newUnit);
            }

            actionPhaseManager.Value.vagues.Add(vaguedata);
            unitsToInvoke.Clear();
        }

        public void AddUnitToVague()
        {
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(0, 0, 0)));
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(1, 0, 0)));
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(-1, 0, 0)));
            Raise();
        }

        public UnitToInvoke AddUnitsToInvoke(UnitToInvoke unitToInvoke)
        {
            unitsToInvoke.Add(unitToInvoke);
            return unitToInvoke;
        }
    }

    [System.Serializable]
    public class VagueData
    {
        public List<CrabsUnit> crabUnits;

        public VagueData()
        {
            crabUnits = new List<CrabsUnit>();
        }
    }

    [System.Serializable]
    public class UnitToInvoke
    {
        public GeneralCrabData generalCrabData;
        public Vector3 position;
        public int followerToInvoke;

        public UnitToInvoke(GeneralCrabData generalCrabData, int followerToInvoke, Vector3 position)
        {
            this.generalCrabData = generalCrabData;
            this.followerToInvoke = followerToInvoke;
            this.position = position;
        }
    }
}