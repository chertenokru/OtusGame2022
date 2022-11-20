using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class MoveMechanics_KeyActions : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        [Required]
        private Transform targetTransform;
        [SerializeField]
        [Required]
        private IntBehaviour speed;

        private void OnEnable()
        {
            gameInputActionSourceReceiver.OnEvent += OnInputAction;
        }

        private void OnDisable()
        {
            gameInputActionSourceReceiver.OnEvent -= OnInputAction;
        }
        private void OnInputAction(GameInputAction action)
        {
            switch (action)
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
            }
        }

        private void Move(Vector3 direction)
        {
            targetTransform.position += direction * (speed.Value * Time.deltaTime);
        }
    }

}