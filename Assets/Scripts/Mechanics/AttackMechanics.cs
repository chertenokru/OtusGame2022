using UnityEngine;

namespace Mechanics
    {
    public sealed class AttackMechanics : MonoBehaviour
        {
        [SerializeField]
        private EventReceiver attackSourceReciver;
        [SerializeField]
        private TimerBehaviour countdown;
        [SerializeField]
        private Enemy enemyTarget;
        [SerializeField]
        private IntBehaviour attackDamage;


        private void OnEnable()
            {
            attackSourceReciver.OnEvent += attack;
            }
        private void OnDisable()
            {
            attackSourceReciver.OnEvent -= attack;
            }

        void attack()
            {
            if(countdown.IsPlaying)
                return;
            else
                {
                enemyTarget?.TakeDamage(attackDamage.Value);
                countdown.ResetTime();
                countdown.Play();
                }
            }
        }
    }
