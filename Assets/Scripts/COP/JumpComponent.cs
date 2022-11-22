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
        [SerializeField]
        [Required]
        private IntBehaviour jumpForce;
        public void Jump()
        {
            receiverTargetJump.Call();
        }

        public int GetJumpForce()
        {
            return jumpForce.Value;
        }
    }
}
