using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class JumpComponent : MonoBehaviour, IJumpComponent
    {
        [SerializeField]
        [Required]
        private EventReceiver receiverTargetJump;

        public void Jump()
        {
            receiverTargetJump.Call();
        }

    }
}
