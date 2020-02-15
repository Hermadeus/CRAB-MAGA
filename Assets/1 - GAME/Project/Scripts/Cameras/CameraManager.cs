using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

using Sirenix.OdinInspector;

namespace CRABMAGA
{
    public class CameraManager : SerializedMonoBehaviour
    {
        public Camera Camera;

        public Vector3 offset = new Vector3();

        [SerializeField] private Transform currentTarget = default;

        bool inTransition = false;

        public float transitionTiming = 3f;
        public Ease transitionEase = Ease.InSine;

        public ActionPhaseManager actionPhaseManager = default;

        public Dictionary<string, Transform> targetPositionsInMap = new Dictionary<string, Transform>();

        Tween transitionTween;

        public Transform CurrentTarget
        {
            get => currentTarget;
            set
            {
                currentTarget = value;
            }
        }

        private void Awake()
        {
            SetCurrentTarget("map_haut");
        }

        private void Update()
        {
            if (inTransition || CurrentTarget == null)
                return;

            Camera.transform.position = CurrentTarget.transform.position + offset;
        }

        [Button]
        public void SetCurrentTarget(Transform newTarget)
        {
            CurrentTarget = newTarget;
        }

        [Button]
        public void GoToMapHaut()
        {
            Transform t;
            targetPositionsInMap.TryGetValue("map_haut", out t);

            Camera.transform.position = t.position;
            CurrentTarget = t;
        }

        public void SetCurrentTarget(string name)
        {
            Transform t;
            targetPositionsInMap.TryGetValue(name, out t);
            SetCurrentTarget(t);
        }

        public void TransitionTo(Transform _transform, float time)
        {
            DOTween.Kill(transitionTween);
            Vector3 to = new Vector3(Camera.transform.position.x, Camera.transform.position.y, _transform.position.z);

            CurrentTarget = _transform;

            inTransition = true;
            transitionTween = DOTween.To(() => Camera.transform.position, x => Camera.transform.position = x, to, time).SetEase(transitionEase).OnComplete(TransitionToFalse);
        }

        public void TransitionTo(Transform _transform)
        {
            TransitionTo(_transform, transitionTiming);
        }

        public void TransitionTo(string name)
        {
            Transform t;
            targetPositionsInMap.TryGetValue(name, out t);

            TransitionTo(t, transitionTiming);
        }

        void TransitionToFalse()
        {
            inTransition = false;
        }

        public void SetTargetOnWave(int waveIndex)
        {
            SetCurrentTarget(actionPhaseManager.vagues[waveIndex].crabUnits[0].leaderCrab.transform);
        }

        public void SetTargetOnWave(VagueData wave)
        {
            SetCurrentTarget(wave.crabUnits[0].leaderCrab.transform);
        }
    }
}