using Components.Interfaces;
using Entities;
using Mechanics;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Components
{
    public class OnDeathSubscriptionComponent : MonoBehaviour, IOnDeathSubscriptionComponent
    {
        [SerializeField]
        [Required]
        private EntityEventReceiver receiver;

        public event Action<IEntity> OnDeath
        {
            add { receiver.OnEvent += value; }
            remove { receiver.OnEvent -= value; }
        }
    }
}

