using Components.Interfaces;
using Mechanics;
using System;
using UnityEngine;

namespace Components
{
    [AddComponentMenu("GameEngine/Mechanics/Component «Two Trigger Events»")]
    public sealed class Component_TwoTriggerEvents : MonoBehaviour, ITriggerTwoColliderEventsComponent
    {
        public event Action<Collider, Collider> OnEntered
        {
            add { eventReceiver.OnTriggerEntered += value; }
            remove { eventReceiver.OnTriggerExited -= value; }
        }

        public event Action<Collider, Collider> OnStaying
        {
            add { eventReceiver.OnTriggerStaying += value; }
            remove { eventReceiver.OnTriggerStaying -= value; }
        }

        public event Action<Collider, Collider> OnExited
        {
            add { eventReceiver.OnTriggerExited += value; }
            remove { eventReceiver.OnTriggerExited -= value; }
        }

        [SerializeField]
        private EventReceiver_TriggerTwoCollider eventReceiver;
    }
}