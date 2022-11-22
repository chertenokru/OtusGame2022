using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [SerializeField]
        [Required]
        private EventReceiver receiver;
        public void Attack()
        {
            receiver.Call();
        }
    }
}
