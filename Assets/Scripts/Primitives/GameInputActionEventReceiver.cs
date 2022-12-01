
using Const;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{

    public class GameInputActionEventReceiver : MonoBehaviour
    {
        public event Action<GameInputAction> OnEvent;

        [Button]
        public void Call(GameInputAction action)
        {
            OnEvent?.Invoke(action);
        }
    }
}
