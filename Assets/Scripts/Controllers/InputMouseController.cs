using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Mechanics;
using Services;
using System;
using UnityEngine;

namespace Cotrollers
{

    public sealed class InputMouseController : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener, IResumeGameListener, IPauseGameListener
    {
        [SerializeField]
        private GameInputAction leftButtonClick;
        [SerializeField]
        private GameInputAction rigthButtonClick;
        [SerializeField]
        private GameInputAction middleButtonClick;
        [SerializeField]
        private GameInputAction sideButtonClick;

        public Action<GameInputAction> Action;

        private GameInputActionEventReceiver inputTargetReceiver;

        void IConstructListener.Construct(IGameContext context)
        {
            inputTargetReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
        }

        private void Update()
        {
            if(Input.GetMouseButton(0)) inputTargetReceiver.Call(leftButtonClick);
            if(Input.GetMouseButton(1)) inputTargetReceiver.Call(rigthButtonClick);
            if(Input.GetMouseButton(2)) inputTargetReceiver.Call(middleButtonClick);
            if(Input.GetMouseButton(3)) inputTargetReceiver.Call(sideButtonClick);
        }

        private void Awake()
        {
            enabled = false;
        }

        void IStartGameListener.OnStartGame()
        {
            enabled = true;
        }

        void IFinishGameListener.OnFinishGame()
        {
            enabled = false;
        }

        public void OnPauseGame()
        {
            enabled = false;
        }

        public void OnResumeGame()
        {
            enabled = true;
        }
    }
}