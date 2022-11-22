using Components;
using Const;
using Entities;
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public class MoveController_InputActions : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        [Required]
        private UnityEntity unit;

        private IMoveComponent moveComponent;

        private void OnEnable()
        {
            gameInputActionSourceReceiver.OnEvent += OnInputAction;
            moveComponent = unit.Get<IMoveComponent>();
        }

        private void OnDisable()
        {
            gameInputActionSourceReceiver.OnEvent -= OnInputAction;
            moveComponent = null;
        }
        protected virtual void OnInputAction(GameInputAction action)
        {
            /// тут такое себе, я потом подумаю как это правильнее сделать
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
            moveComponent.Move(direction * (moveComponent.GetSpeed() * Time.deltaTime));
        }
    }

}