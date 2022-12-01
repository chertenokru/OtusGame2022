using Entities;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{

    public class EntityEventReceiver : MonoBehaviour
    {
        public event Action<IEntity> OnEvent;

        [PropertySpace(8)]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Call(IEntity entity)
        {
            //Debug.Log($"Event {name} Received");
            this.OnEvent?.Invoke(entity);
        }
    }
}
