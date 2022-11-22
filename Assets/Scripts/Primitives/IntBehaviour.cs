using System;
using UnityEngine;

namespace Mechanics
{
    public class IntBehaviour : MonoBehaviour
    {
        public event Action<int> OnEvent;
        public int Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnEvent?.Invoke(value);
            }
        }

        [SerializeField]
        private int value;

    }

}
