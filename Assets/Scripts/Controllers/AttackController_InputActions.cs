using Components;
using Const;
using Entities;
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public class AttackController_InputActions : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver gameInputActionSourceReceiver;
        [SerializeField]
        [Required]
        private UnityEntity unit;

        private IAttackComponent attackComponent;

        private void OnEnable()
        {
            gameInputActionSourceReceiver.OnEvent += OnAttackAction;
            attackComponent = unit.Get<IAttackComponent>();
        }

        private void OnDisable()
        {
            gameInputActionSourceReceiver.OnEvent -= OnAttackAction;
            attackComponent = null;
        }
        protected virtual void OnAttackAction(GameInputAction action)
        {
            if (action == GameInputAction.Fire) attackComponent.Attack();
        }
    }

}

