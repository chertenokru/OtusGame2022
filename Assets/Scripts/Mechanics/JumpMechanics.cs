using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class JumpMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver jumpEventSourceReceiver;
        [SerializeField]
        [Required]
        private IntBehaviour jumpForce;
        [SerializeField]
        [Required]
        private Transform[] moveTransforms;

        private float accumY = 0;
        private float currentJumpSpeed;
        private bool isJump;
        private float gravity = Physics.gravity.y;

        private void OnEnable()
        {
            jumpEventSourceReceiver.OnEvent += OnJump;
            isJump = false;
        }

        private void OnDisable()
        {
            jumpEventSourceReceiver.OnEvent -= OnJump;
        }

        private void FixedUpdate()
        {
            if (isJump)
            {
                currentJumpSpeed += gravity * Time.fixedDeltaTime;
                var y = currentJumpSpeed * Time.fixedDeltaTime;
                accumY += y;
                if (accumY < 0) y -= accumY;
                Move(new Vector3(0, y, 0));
                if (accumY <= 0) isJump = false;
            }
        }

        public void OnJump()
        {
            if (!isJump)
            {
                currentJumpSpeed = jumpForce.Value;
                accumY = 0;
                isJump = true;
            }
        }

        private void Move(Vector3 moveVector)
        {
            foreach (var item in moveTransforms)
            {
                item.position += moveVector;
            }
        }
    }
}
