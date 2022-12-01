using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{
    [DisallowMultipleComponent]
    public sealed class EventReceiver_TriggerTwoCollider : MonoBehaviour
    {
        [SerializeField]
        [ReadOnly]
        private Collider self;

        public event Action<Collider, Collider> OnTriggerEntered;
        public event Action<Collider, Collider> OnTriggerStaying;
        public event Action<Collider, Collider> OnTriggerExited;

        private void Awake()
        {
            self = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            this.OnTriggerEntered?.Invoke(self, other);
        }

        private void OnTriggerStay(Collider other)
        {
            this.OnTriggerStaying?.Invoke(self, other);
        }

        private void OnTriggerExit(Collider other)
        {
            this.OnTriggerExited?.Invoke(self, other);
        }
    }
}
