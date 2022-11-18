
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
    {

    public class EventReceiver : MonoBehaviour
        {
        public event Action OnEvent;

        [Button]
        public void Call()
            {
            Debug.Log($"Event {name} Received");
            this.OnEvent?.Invoke();
            }
        }
    }
