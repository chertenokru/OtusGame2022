using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class JumpMechanics_KeyActions : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        [Required]
        private Transform targetTransform;
        [SerializeField]
        [Required]
        private IntBehaviour jump;

        private float accumY = 0;
        private float currentJumpSpeed;
        private bool isJump;
        private float gravity = Physics.gravity.y;

        private void OnEnable()
        {
            gameInputActionSourceReceiver.OnEvent += OnInputAction;
            isJump = false;
        }

        private void OnDisable()
        {
            gameInputActionSourceReceiver.OnEvent -= OnInputAction;
        }


        private void FixedUpdate()
        {
            if (isJump)
            {
                currentJumpSpeed += gravity * Time.fixedDeltaTime;
                var y = currentJumpSpeed * Time.fixedDeltaTime;
                accumY += y;
                if (accumY < 0) y -= accumY;
                targetTransform.position += new Vector3(0, y, 0);
                if (accumY <= 0) isJump = false;
            }
        }

        private void OnInputAction(GameInputAction action)
        {
            if (action == GameInputAction.Jump)
                if (!isJump)
                {
                    currentJumpSpeed = jump.Value;
                    accumY = 0;
                    isJump = true;
                }
        }

    }

}