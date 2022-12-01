using Cinemachine;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Services.Interfaces;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace Services
{
    public sealed class CameraTransformService : MonoBehaviour, IConstructListener, ICameraTransformService
    {
        [SerializeField]
        private Vector3 startPosition;
        [SerializeField]
        private bool currentPostionStart;

        [SerializeField]
        private Vector3 endPosition;
        [SerializeField]
        private bool currentPostionEnd;
        [SerializeField]
        [Required]
        private float timeToPlay;

        public Vector3 StartPosition { get => startPosition; set => startPosition = value; }
        public bool CurrentPostionStart { get => currentPostionStart; set => currentPostionStart = value; }
        public Vector3 EndPosition { get => endPosition; set => endPosition = value; }
        public bool CurrentPostionEnd { get => currentPostionEnd; set => currentPostionEnd = value; }
        public float TimeToPlay { get => timeToPlay; set => timeToPlay = value; }

        public event Action OnEnd;

        private IGameContext context;
        private float currentTime = 0;


        public void Play()
        {
            var s = StartCoroutine(MoveCamera());
        }

        private void FixedUpdate()
        {
            currentTime += Time.fixedDeltaTime;
        }

        public IEnumerator MoveCamera()
        {
            var camera = context.GetService<CameraService>().Camera;


            var current = camera.GetComponentInChildren<CinemachineTransposer>().m_FollowOffset;
            var start = (currentPostionStart) ? current : startPosition;
            var end = (currentPostionEnd) ? current : endPosition;
            currentTime = 0f;
            while(currentTime <= timeToPlay)
            {
                camera.GetComponentInChildren<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(start, end, currentTime / timeToPlay);
                yield return null;
                //   currentTime += Time.deltaTime;
            }
            OnEnd?.Invoke();
        }

        public void Construct(IGameContext context)
        {
            this.context = context;
        }
    }
}
