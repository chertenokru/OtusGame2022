
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{

    public class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [PropertySpace(8)]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Call()
        {

            this.OnEvent?.Invoke();
        }
    }
}
