using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CRABMAGA {
    [CreateAssetMenu(menuName = "CRAB MAGA/Action Phase/Vague")]
    public class Vague : ScriptableWithDescription
    {
        public ICrabFactory unitFactory = default;

        public List<UnitToInvoke> unitsToInvoke = new List<UnitToInvoke>();

        public GeneralCrabData generalCrab = default;

        public void Raise()
        {
            for (int i = 0; i < unitsToInvoke.Count; i++)
            {
                unitFactory.InstantiateCrabsUnit(unitsToInvoke[i].generalCrabData,
                    unitsToInvoke[i].followerToInvoke,
                    unitsToInvoke[i].position);
            }
        }

        public void TestAddUnit()
        {
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(0, 0, 0)));
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(1, 0, 0)));
            AddUnitsToInvoke(new UnitToInvoke(generalCrab, generalCrab.followersMax, new Vector3(-1, 0, 0)));
            Raise();
        }

        public void AddUnitsToInvoke(UnitToInvoke unitToInvoke)
        {
            unitsToInvoke.Add(unitToInvoke);
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