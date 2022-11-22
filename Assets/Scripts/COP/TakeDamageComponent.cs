
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        [SerializeField]
        [Required]
        private IntEventReceiver damageTargetReciver;

        public void TakeDamage(int damage)
        {
            damageTargetReciver.Call(damage);
        }
    }
}
