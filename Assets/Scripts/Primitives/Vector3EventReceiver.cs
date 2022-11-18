using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
    {
    public sealed class Vector3EventReceiver : MonoBehaviour
        {
        public event Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 vector)
            {
            this.OnEvent?.Invoke(vector);
            }
        }
    }