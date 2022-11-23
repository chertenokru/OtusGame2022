using Components;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class AttackBulletMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver fireSourceReciver;
        [SerializeField]
        [Required]
        private IntEventReceiver setDamageSourceReciver;
        [SerializeField]
        [Required]
        private TimerBehaviour delay;
        [SerializeField]
        [Required]
        private GameObject bullet;
        [SerializeField]
        [Required]
        private Transform createPosition;
        [SerializeField]
        [Required]
        private IntBehaviour attackDamage;

        private void OnEnable()
        {
            fireSourceReciver.OnEvent += Attack;
            setDamageSourceReciver.OnEvent += SetNewDamage;
        }
        private void OnDisable()
        {
            fireSourceReciver.OnEvent -= Attack;
            setDamageSourceReciver.OnEvent -= SetNewDamage;
        }

        private void SetNewDamage(int newDamage)
        {
            attackDamage.Value = newDamage;
        }

        void Attack()
        {
            if (!delay.IsPlaying)
            {
                var newBullet = Instantiate(bullet, createPosition.position, Quaternion.identity);

                if (newBullet.TryGetComponent(out IEntity entity))
                {
                    entity.TryGet(out ISetDamageComponent setDamageBullet);
                    setDamageBullet.SetDamage(attackDamage.Value);
                }
                delay.ResetTime();
                delay.Play();
            }
        }
    }
}
