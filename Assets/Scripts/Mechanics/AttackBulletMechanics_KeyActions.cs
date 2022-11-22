using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class AttackBulletMechanics_KeyActions : MonoBehaviour
    {
        [SerializeField]
        private EventReceiver fireKeySourceReciver;
        [SerializeField]
        private TimerBehaviour delay;
        [SerializeField]
        [Required]
        private GameObject bullet;
        [SerializeField]
        private Transform createPosition;
        [SerializeField]
        private IntBehaviour attackDamage;

        private void OnEnable()
        {
            fireKeySourceReciver.OnEvent += Attack;
        }
        private void OnDisable()
        {
            fireKeySourceReciver.OnEvent -= Attack;
        }

        void Attack()
        {
            if (!delay.IsPlaying)
            {
                Instantiate(bullet, createPosition.position, Quaternion.identity);
                delay.ResetTime();
                delay.Play();
            }
        }
    }
}
