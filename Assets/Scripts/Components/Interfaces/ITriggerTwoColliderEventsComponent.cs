using System;
using UnityEngine;

namespace Components.Interfaces
{
    public interface ITriggerTwoColliderEventsComponent
    {
        event Action<Collider, Collider> OnEntered;
        event Action<Collider, Collider> OnStaying;
        event Action<Collider, Collider> OnExited;
    }
}