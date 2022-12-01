using System;
using UnityEngine;

namespace Components.Interfaces
{
    public interface ITriggerEventsComponent
    {
        event Action<Collider> OnEntered;

        event Action<Collider> OnStaying;

        event Action<Collider> OnExited;
    }
}