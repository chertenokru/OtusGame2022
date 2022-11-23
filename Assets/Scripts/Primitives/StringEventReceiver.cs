
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{

    public class StringEventReceiver : MonoBehaviour
    {
        public event Action<String> OnEvent;

        [Button]
        public void Call(string value)
        {
            //Debug.Log($"Event {name} Received");
            this.OnEvent?.Invoke(value);
        }
    }
}
