using UnityEngine;

namespace Mechanics
    {
    public sealed class AttackBulletMechanics : MonoBehaviour
        {
        [SerializeField]
        private GameInputActionEventReceiver fireKeySourceReciver;
        [SerializeField]
        private TimerBehaviour delay;
        [SerializeField]
        private GameObject bullet;
        [SerializeField]
        private Transform createPosition;
        [SerializeField]
        private IntBehaviour attackDamage;


        private void OnEnable()
            {
            fireKeySourceReciver.OnEvent += attack;
            }
        private void OnDisable()
            {
            fireKeySourceReciver.OnEvent -= attack;
            }

        void attack(GameInputAction action)
            {
            if(action == GameInputAction.Fire && !delay.IsPlaying)
                {
                Instantiate(bullet, createPosition.position, Quaternion.identity);
                delay.ResetTime();
                delay.Play();
                }
            }
        }
    }
