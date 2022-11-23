using Components;
using Const;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class JumpController_InputActions : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        [Required]
        private UnityEntity unit;

        private IJumpComponent jumpComponent;


        private void OnEnable()
        {
            gameInputActionSourceReceiver.OnEvent += OnJumpAction;
            jumpComponent = unit.Get<IJumpComponent>();
        }

        private void OnDisable()
        {
            gameInputActionSourceReceiver.OnEvent -= OnJumpAction;
            jumpComponent = null;
        }

        private void OnJumpAction(GameInputAction action)
        {
            if (action == GameInputAction.Jump) jumpComponent.Jump();
        }
    }
}