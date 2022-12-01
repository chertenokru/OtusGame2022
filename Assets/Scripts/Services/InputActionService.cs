using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Services
{
    public sealed class InputActionService : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver inputActionReceiver;

        public GameInputActionEventReceiver GetInputActionReceiver()
        {
            return inputActionReceiver;
        }

    }
}