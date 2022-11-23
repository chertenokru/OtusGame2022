
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class SetDamageComponent : MonoBehaviour, ISetDamageComponent
    {
        [SerializeField]
        [Required]
        private IntBehaviour damageField;

        public void SetDamage(int damage)
        {
            damageField.Value = damage;
        }
    }
}
