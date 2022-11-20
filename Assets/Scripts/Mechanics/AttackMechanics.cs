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
            attackSourceReciver.OnEvent += Attack;
        }
        private void OnDisable()
        {
            attackSourceReciver.OnEvent -= Attack;
        }

        void Attack()
        {
            if (countdown.IsPlaying)
                return;
            else
            {
                if (enemyTarget) enemyTarget.TakeDamage(attackDamage.Value);
                countdown.ResetTime();
                countdown.Play();
            }
        }
    }
}
