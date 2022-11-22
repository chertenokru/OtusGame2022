using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class DeathMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver deathTargetReceiver;
        [SerializeField]
        private IntBehaviour hitPoints;
        [SerializeField]
        private TimerBehaviour deathTimer;
        [SerializeField]
        private EventReceiver_Trigger deathCollasion;

        private void OnEnable()
        {
            if (hitPoints) hitPoints.OnEvent += OnHitPointsChanged;
            if (deathTimer)
            {
                deathTimer.OnEnded += Death;
                deathTimer.Play();
            }
            if (deathCollasion)
            {
                deathCollasion.OnTriggerEntered += OnTrigetEntry;
            }
        }


        private void OnDisable()
        {
            if (hitPoints) hitPoints.OnEvent -= OnHitPointsChanged;
            if (deathTimer)
            {
                deathTimer.OnEnded -= Death;
                deathTimer.Stop();
            }
            if (deathCollasion)
            {
                deathCollasion.OnTriggerEntered -= OnTrigetEntry;
            }
        }
        private void OnHitPointsChanged(int newValue)
        {
            if (newValue <= 0) Death();
        }
        private void OnTrigetEntry(Collider other)
        {
            //if (!other.TryGetComponent(out IEntity entity))
            //{
            //    Debug.Log($"NOT ENTITY {other.name}");
            //    return;
            //}

            //if (!entity.TryGet(out IDeathComponent deathComponent))
            //{
            //    Debug.Log($"NO COMPONENT {other.name}");
            //    return;
            //}
            //deathComponent.Death();
            Death();
        }

        private void Death()
        {
            if (deathTargetReceiver) deathTargetReceiver.Call();
        }
    }

}
