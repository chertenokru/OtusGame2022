using Const;
using Mechanics;
using System;
using UnityEngine;

namespace Cotrollers
{
    public class InputKeyController : MonoBehaviour
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
        private KeyCode jump;
        [SerializeField]
        private KeyCode fire;
        [SerializeField]
        private GameInputActionEventReceiver inputTargetReceiver;

        public Action<GameInputAction> Action;
        private GameInputAction currentAction = GameInputAction.None;

        private void Update()
        {
            currentAction = GameInputAction.None;

            if (Input.GetKey(left)) currentAction = GameInputAction.Left;
            if (Input.GetKey(right)) currentAction = GameInputAction.Right;
            if (Input.GetKey(top)) currentAction = GameInputAction.Top;
            if (Input.GetKey(bottom)) currentAction = GameInputAction.Bottom;
            if (Input.GetKey(jump)) currentAction = GameInputAction.Jump;
            if (Input.GetKey(fire)) currentAction = GameInputAction.Fire;

            if (currentAction != GameInputAction.None) inputTargetReceiver.Call(currentAction);
        }



    }
}