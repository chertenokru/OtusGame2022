using Const;
using System;
using UnityEngine;

namespace Mechanics
{
    public class GameObjectTypeBehaviour : MonoBehaviour
    {
        public event Action<GameObjectType> OnEvent;
        public GameObjectType Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnEvent?.Invoke(value);
            }
        }

        [SerializeField]
        private GameObjectType value;

    }

}
