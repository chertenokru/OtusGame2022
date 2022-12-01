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
    public sealed class ChangeWeaponController_InputActions : MonoBehaviour, IStartGameListener, IFinishGameListener, IConstructListener
    {
        [SerializeField]
        private float keyPressDelay = 1f;
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        private IChangeWeaponComponent attackComponent;
        private float lastKeyPressTime = 0;

        void IConstructListener.Construct(IGameContext context)
        {
            gameInputActionSourceReceiver = context.GetService<InputActionService>().GetInputActionReceiver();
            attackComponent = context.GetService<ICharacterService>().GetCharacter().Get<IChangeWeaponComponent>();
        }

        void OnChangeAction(GameInputAction action)
        {
            if(action == GameInputAction.ChangeWeapon)
            {
                if(Time.time - lastKeyPressTime > keyPressDelay)
                {
                    attackComponent.Change();
                    lastKeyPressTime = Time.time;
                }
            }
        }

        void IStartGameListener.OnStartGame()
        {
            gameInputActionSourceReceiver.OnEvent += OnChangeAction;
        }

        void IFinishGameListener.OnFinishGame()
        {
            gameInputActionSourceReceiver.OnEvent -= OnChangeAction;
        }


    }

}

