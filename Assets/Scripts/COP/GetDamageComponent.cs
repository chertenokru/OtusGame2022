
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class GetDamageComponent : MonoBehaviour, IGetDamageComponent
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
