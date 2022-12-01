using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Component «Collision Events»")]
    public sealed class Component_CollisionEvents : MonoBehaviour
    {
        public event Action<Collision> OnCollisionEntered
        {
            add { this.eventReceiver.OnCollisionEntered += value; }
            remove { this.eventReceiver.OnCollisionEntered -= value; }
        }

        public event Action<Collision> OnCollisionStaying
        {
            add { this.eventReceiver.OnCollisionStaying += value; }
            remove { this.eventReceiver.OnCollisionStaying -= value; }
        }

        public event Action<Collision> OnCollisionExited
        {
            add { this.eventReceiver.OnCollisionExited += value; }
            remove { this.eventReceiver.OnCollisionExited -= value; }
        }

        [SerializeField]
        private EventReceiver_Collision eventReceiver;
    }
}