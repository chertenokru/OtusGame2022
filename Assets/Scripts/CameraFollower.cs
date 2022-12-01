

using Cinemachine;
using Components.Interfaces;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Services;
using Services.Interfaces;
using UnityEngine;

namespace Scripts
{
    public sealed class CameraFollower : MonoBehaviour, IConstructListener, IStartGameListener, IFinishGameListener
    {
        private CinemachineVirtualCamera targetCamera;
        private IGetTransformComponent characterComponent;


        void IConstructListener.Construct(IGameContext context)
        {
            targetCamera = context.GetService<CameraService>().Camera;

            characterComponent = context.GetService<ICharacterService>()
                .GetCharacter()
                .Get<IGetTransformComponent>();
            targetCamera.Follow = characterComponent.GetTransform();
            targetCamera.LookAt = characterComponent.GetTransform();

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

    }
}
