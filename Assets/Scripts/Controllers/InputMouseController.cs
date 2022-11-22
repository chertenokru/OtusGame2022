using Const;
using Mechanics;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Cotrollers
{

    public class InputMouseController : MonoBehaviour
    {
        [SerializeField]
        private GameInputAction leftButtonClick;
        [SerializeField]
        private GameInputAction rigthButtonClick;
        [SerializeField]
        private GameInputAction middleButtonClick;
        [SerializeField]
        private GameInputAction sideButtonClick;
        [SerializeField]
        [Required]
        private GameInputActionEventReceiver inputTargetReceiver;

        public Action<GameInputAction> Action;


        private void Update()
        {
            if (Input.GetMouseButton(0)) inputTargetReceiver.Call(leftButtonClick);
            if (Input.GetMouseButton(1)) inputTargetReceiver.Call(rigthButtonClick);
            if (Input.GetMouseButton(2)) inputTargetReceiver.Call(middleButtonClick);
            if (Input.GetMouseButton(3)) inputTargetReceiver.Call(sideButtonClick);
        }
    }
}