using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Mechanics;
using Services;
using UnityEngine;

namespace Controllers
{
    public sealed class PauseController_InputActions : MonoBehaviour, IConstructListener, IPauseGameListener, IResumeGameListener, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        private float keyPressDelay = 1f;

        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        private IGameContext context;
        private bool isPause;
        private float lastKeyPressTime = 0;


        private void OnkeyAction(GameInputAction action)
        {
            if(action == GameInputAction.Pause)
            {
                if((Time.unscaledTime - lastKeyPressTime > keyPressDelay))
                {
                    if(isPause) context.ResumeGame();
                    else
                        context.PauseGame();
                    lastKeyPressTime = Time.unscaledTime;
                }
            }
        }
        void IStartGameListener.OnStartGame()
        {
            gameInputActionSourceReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
            gameInputActionSourceReceiver.OnEvent += OnkeyAction;
            isPause = false;
        }
        void IFinishGameListener.OnFinishGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnkeyAction;
            isPause = false;
        }

        void IConstructListener.Construct(IGameContext context)
        {
            this.context = context;
            isPause = false;
        }

        public void OnResumeGame()
        {
            isPause = false;
        }

        public void OnPauseGame()
        {
            isPause = true;
        }
    }
}