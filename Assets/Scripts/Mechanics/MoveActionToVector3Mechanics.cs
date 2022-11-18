using UnityEngine;

namespace Mechanics
    {
    public sealed class MoveActionToVector3Mechanics : MonoBehaviour
        {
        [SerializeField]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        private Vector3EventReceiver vector3EventTargetReceiver;
        [SerializeField]
        private IntBehaviour speed;
        [SerializeField]
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
            if(isJump)
                {
                currentJumpSpeed += gravity * Time.fixedDeltaTime;
                var y = currentJumpSpeed * Time.fixedDeltaTime;
                accumY += y;
                if(accumY < 0) y -= accumY;
                vector3EventTargetReceiver.Call(new Vector3(0, y, 0));
                if(accumY <= 0) isJump = false;
                }
            }

        private void OnInputAction(GameInputAction action)
            {
            switch(action)
                {
                case GameInputAction.Left:
                    Move(Vector3.left);
                    break;
                case GameInputAction.Right:
                    Move(Vector3.right);
                    break;
                case GameInputAction.Top:
                    Move(Vector3.forward);
                    break;
                case GameInputAction.Bottom:
                    Move(Vector3.back);
                    break;
                case GameInputAction.Jump:
                    if(!isJump)
                        {
                        currentJumpSpeed = jump.Value;
                        accumY = 0;
                        isJump = true;
                        }
                    break;
                }

            }


        private void Move(Vector3 direction)
            {
            vector3EventTargetReceiver.Call((direction * (speed.Value * Time.deltaTime)));
            }
        }

    }