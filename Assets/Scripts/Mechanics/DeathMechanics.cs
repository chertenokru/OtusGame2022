using UnityEngine;

namespace Mechanics
    {
    public sealed class DeathMechanics : MonoBehaviour
        {
        [SerializeField]
        private EventReceiver deathTargetReceiver;
        [SerializeField]
        private IntBehaviour hitPoints;
        [SerializeField]
        private TimerBehaviour deathTimer;


        private void OnEnable()
            {
            if(hitPoints) hitPoints.OnValueChanged += OnHitPointsChanged;
            if(deathTimer)
                {
                deathTimer.OnEnded += Death;
                deathTimer.Play();
                }

            }


        private void OnDisable()
            {
            if(hitPoints) hitPoints.OnValueChanged -= OnHitPointsChanged;
            if(deathTimer)
                {
                deathTimer.OnEnded -= Death;
                deathTimer.Stop();
                }
            }

        private void OnHitPointsChanged(int newValue)
            {
            if(newValue <= 0) Death();

            }


        private void Death()
            {
            deathTargetReceiver?.Call();
            }
        }

    }
