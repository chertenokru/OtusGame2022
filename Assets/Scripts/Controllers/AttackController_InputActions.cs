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
    public sealed class AttackController_InputActions : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener, IResumeGameListener, IPauseGameListener
    {
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        private IAttackComponent attackComponent;

        void IConstructListener.Construct(IGameContext context)
        {
            gameInputActionSourceReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
            attackComponent = context.GetService<ICharacterService>().GetCharacter().Get<IAttackComponent>();
        }

        void OnAttackAction(GameInputAction action)
        {
            if(action == GameInputAction.Fire) attackComponent.Attack();
        }

        void IStartGameListener.OnStartGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnAttackAction;
        }

        void IFinishGameListener.OnFinishGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnAttackAction;
        }

        public void OnPauseGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnAttackAction;
        }

        public void OnResumeGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnAttackAction;
        }
    }

}

