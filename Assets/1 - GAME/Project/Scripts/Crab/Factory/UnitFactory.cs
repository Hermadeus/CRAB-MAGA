using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CRABMAGA
{
    [CreateAssetMenu(menuName = "CRAB MAGA/Factory/Crab Unity Factory")]
    public class UnitFactory : ScriptableWithDescription
    {
        /// <summary>
        /// IMPORTANT ----------------- IMPORTANT
        /// 
        /// Depuis ce script:
        /// --> Instantiation d'une unité
        /// --> Instantiation d'un général
        /// --> Instantiation d'un follower
        /// 
        /// </summary>



        public ICrabFactory crabFollowerFactory = default;

        /// <summary>
        /// Instantie une unité avec un général.
        /// crab = le general à instancier,
        /// position = la position d'apparition du général
        /// quantite = le nombre de follower à instancier
        /// parent = transform où stocker les unités (dans l'absolu parent = null)
        /// </summary>
        public Crab InstantiateCrab(Crab crab, Vector3 position, int? quantite, Transform parent)
        {
            //Création d'un GameObject vide "UNIE DE CRAB"
            GameObject unitParent = new GameObject("Unité de crabe");
            if(parent != null)
                unitParent.transform.parent = parent;

            //Initialisation de l'object en CrabsUnity
            CrabsUnit crabsUnity = unitParent.AddComponent<CrabsUnit>();

            //Création d'un GameObject vide pour acceuillir les followers
            GameObject followerParent = new GameObject("Followers");
            followerParent.transform.parent = unitParent.transform;

            //Instantiation du général
            GeneralCrab general = Instantiate(crab, position, Quaternion.identity, unitParent.transform) as GeneralCrab;
            Crab leader = crabsUnity.leader = general;

            //Instantiation des followers
            Crab[] crabsFollowers = crabFollowerFactory.InstantiateCrabs(crabsUnity.leader.generalCrabData.crabFollowerPrefab,
                followerParent.transform.position,
                crabsUnity.leader.generalCrabData.followersMax,
                followerParent.transform
                );

            foreach (CrabFollower cf in crabsFollowers)
                cf.generalCrab = general;

            return leader;
        }

        public Crab[] InstantiateCrabs(Crab crab, Vector3 position, int? quantite, Transform parent)
        {
            GameObject unitParent = new GameObject("Unité de crabe");
            if (parent != null)
                unitParent.transform.parent = parent;

            //Initialisation de l'object en CrabsUnity
            CrabsUnit crabsUnity = unitParent.AddComponent<CrabsUnit>();

            //Création d'un GameObject vide pour acceuillir les followers
            GameObject followerParent = new GameObject("Followers");
            followerParent.transform.parent = unitParent.transform;

            //Instantiation du général
            GeneralCrab general = Instantiate(crab, position, Quaternion.identity, unitParent.transform) as GeneralCrab;
            Crab leader = crabsUnity.leader = general;

            //Instantiation des followers
            Crab[] crabsFollowers = crabFollowerFactory.InstantiateCrabs(crabsUnity.leader.generalCrabData.crabFollowerPrefab,
                followerParent.transform.position,
                crabsUnity.leader.generalCrabData.followersMax,
                followerParent.transform
                );

            foreach (CrabFollower cf in crabsFollowers)
                cf.generalCrab = general;

            return crabsFollowers;
        }

        public CrabsUnit InstantiateCrabsUnit(Crab general, Crab follower, int quantiteFollower, Vector3 position)
        {
            throw new System.NotImplementedException();
        }

    }
}
