using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class DeathSubsriptionMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver deathSourceReceiver;
        [SerializeField]
        [Required]
        private UnityEntity entity;
        [SerializeField]
        [Required]
        private EntityEventReceiver deathTargetReceiver;

        private void OnEnable()
        {
            deathSourceReceiver.OnEvent += OnDeath;
        }

        private void OnDisable()
        {
            deathSourceReceiver.OnEvent -= OnDeath;
        }

        private void OnDeath()
        {
            deathTargetReceiver.Call(entity);
        }

    }

}
