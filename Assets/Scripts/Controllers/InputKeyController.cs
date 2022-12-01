using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Mechanics;
using Services;
using System;
using UnityEngine;

namespace Cotrollers
{
    public sealed class InputKeyController : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener
    {
        [SerializeField]
        private KeyCode left;
        [SerializeField]
        private KeyCode right;
        [SerializeField]
        private KeyCode top;
        [SerializeField]
        private KeyCode bottom;
        [SerializeField]
        private KeyCode forward;
        [SerializeField]
        private KeyCode back;
        //[SerializeField]
        //private KeyCode jump;
        [SerializeField]
        private KeyCode fire;
        [SerializeField]
        private KeyCode changeWeapon;
        [SerializeField]
        private KeyCode pause = KeyCode.Escape;

        public Action<GameInputAction> Action;

        private GameInputActionEventReceiver inputTargetReceiver;

        void IConstructListener.Construct(IGameContext context)
        {
            inputTargetReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
        }

        private void Update()
        {
            if(Input.GetKey(left)) inputTargetReceiver.Call(GameInputAction.Left);
            if(Input.GetKey(right)) inputTargetReceiver.Call(GameInputAction.Right);
            if(Input.GetKey(top)) inputTargetReceiver.Call(GameInputAction.Top);
            if(Input.GetKey(bottom)) inputTargetReceiver.Call(GameInputAction.Bottom);
            if(Input.GetKey(forward)) inputTargetReceiver.Call(GameInputAction.Forward);
            if(Input.GetKey(back)) inputTargetReceiver.Call(GameInputAction.Back);
            //if (Input.GetKey(jump)) inputTargetReceiver.Call(GameInputAction.Jump);
            if(Input.GetKey(fire)) inputTargetReceiver.Call(GameInputAction.Fire);
            if(Input.GetKey(changeWeapon)) inputTargetReceiver.Call(GameInputAction.ChangeWeapon);
            if(Input.GetKey(pause)) inputTargetReceiver.Call(GameInputAction.Pause);
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

        //public void OnPauseGame()
        //{
        //    enabled = false;
        //}

        //public void OnResumeGame()
        //{
        //    enabled = true;
        //}
    }
}