using Components.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class DeathComponent : MonoBehaviour, IDeathComponent
    {
        [SerializeField]
        [Required]
        private Mechanics.EventReceiver receiver;
        public void Death()
        {
            receiver.Call();
        }
    }
}
