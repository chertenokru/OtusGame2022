using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class DeathComponent : MonoBehaviour, IDeathComponent
    {
        [SerializeField]
        [Required]
        private EventReceiver receiver;
        public void Death()
        {
            receiver.Call();
        }
    }
}
