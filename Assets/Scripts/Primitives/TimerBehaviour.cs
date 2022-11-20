using Sirenix.OdinInspector;
using System;
using System.Collections;
using UnityEngine;

namespace Mechanics
{
    public sealed class TimerBehaviour : MonoBehaviour
    {
        public event Action OnEnded;
        public bool IsPlaying
        {
            get { return this.timerCoroutine != null; }
        }

        [SerializeField]
        public float Duration = 3;

        [ReadOnly]
        [SerializeField]
        private float currentTime;

        private Coroutine timerCoroutine;

        public void Play()
        {

            if (this.timerCoroutine == null)
            {
                this.timerCoroutine = this.StartCoroutine(this.TimerRoutine());
            }
        }

        public void Stop()
        {
            if (this.timerCoroutine != null)
            {
                this.StopCoroutine(this.timerCoroutine);
                this.timerCoroutine = null;
            }
        }

        public void ResetTime()
        {
            this.currentTime = 0;
        }

        private IEnumerator TimerRoutine()
        {
            while (this.currentTime < this.Duration)
            {
                yield return null;
                this.currentTime += Time.deltaTime;
            }

            this.currentTime = this.Duration;
            this.timerCoroutine = null;
            this.OnEnded?.Invoke();
        }
    }
}