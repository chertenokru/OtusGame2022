using UnityEngine;

namespace Mechanics
    {
    public sealed class TakeDamageMechanics : MonoBehaviour
        {
        [SerializeField]
        private IntEventReceiver takeDamageSourceReceiver;
        [SerializeField]
        private IntBehaviour hitPoints;

        private void OnEnable()
            {
            takeDamageSourceReceiver.OnEvent += OnDamageTaken;
            }

        private void OnDisable()
            {
            takeDamageSourceReceiver.OnEvent -= OnDamageTaken;
            }

        private void OnDamageTaken(int damage)
            {
            hitPoints.Value -= damage;
            }
        }
    }

