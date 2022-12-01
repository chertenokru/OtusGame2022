using Components.Interfaces;
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class ChangeWeaponComponent : MonoBehaviour, IChangeWeaponComponent
    {
        [SerializeField]
        [Required]
        private EventReceiver receiver;
        public void Change()
        {
            receiver.Call();
        }
    }
}
