using Entities;
using System;

namespace Components.Interfaces
{
    public interface IOnDeathSubscriptionComponent
    {
        public event Action<IEntity> OnDeath;
    }
}