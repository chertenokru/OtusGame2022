using Components.Interfaces;
using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Mechanics;
using Services;
using Services.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{

    public sealed class MoveController_InputActions : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener, IPauseGameListener, IResumeGameListener
    {
        [SerializeField]
        [ReadOnly]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;

        private IMoveComponent moveComponent;

        void IConstructListener.Construct(IGameContext context)
        {
            gameInputActionSourceReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
            moveComponent = context.GetService<ICharacterService>().GetCharacter().Get<IMoveComponent>();
        }

        void OnInputAction(GameInputAction action)
        {
            /// тут такое себе, я потом подумаю как это правильнее сделать
            switch(action)
            {
                case GameInputAction.Left:
                    Move(Vector3.left);
                    break;
                case GameInputAction.Right:
                    Move(Vector3.right);
                    break;
                case GameInputAction.Top:
                    Move(Vector3.up);
                    break;
                case GameInputAction.Forward:
                    Move(Vector3.forward);
                    break;
                case GameInputAction.Bottom:
                    Move(Vector3.down);
                    break;
                case GameInputAction.Back:
                    Move(Vector3.back);
                    break;
            }
        }

        private void Move(Vector3 direction)
        {
            moveComponent.Move(direction);
        }

        void IStartGameListener.OnStartGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnInputAction;
        }

        void IFinishGameListener.OnFinishGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnInputAction;
        }

        public void OnResumeGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnInputAction;
        }

        public void OnPauseGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnInputAction;
        }
    }

}