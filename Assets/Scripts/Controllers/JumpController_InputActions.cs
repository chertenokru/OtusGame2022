using Components.Interfaces;
using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Mechanics;
using Services;
using Services.Interfaces;
using UnityEngine;

namespace Controllers
{
    public sealed class JumpController_InputActions : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener
    {
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        private IJumpComponent jumpComponent;

        void IConstructListener.Construct(IGameContext context)
        {
            gameInputActionSourceReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
            jumpComponent = context.GetService<ICharacterService>().GetCharacter().Get<IJumpComponent>();
        }

        private void OnJumpAction(GameInputAction action)
        {
            //     if (action == GameInputAction.Jump) jumpComponent.Jump();
        }

        void IStartGameListener.OnStartGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnJumpAction;
        }
        void IFinishGameListener.OnFinishGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnJumpAction;
        }
    }
}