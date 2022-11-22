
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class DamageComponent : MonoBehaviour, IDamageComponent
    {
        [SerializeField]
        [Required]
        private IntBehaviour damage;

        public int GetDamage()
        {
            return damage.Value;
        }
    }
}
