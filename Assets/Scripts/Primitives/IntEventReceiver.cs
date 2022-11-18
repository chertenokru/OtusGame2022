
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
    {

    public class IntEventReceiver : MonoBehaviour
        {
        public event Action<int> OnEvent;

        [Button]
        public void Call(int value)
            {
            Debug.Log($"Event {name} Received");
            this.OnEvent?.Invoke(value);
            }
        }
    }
