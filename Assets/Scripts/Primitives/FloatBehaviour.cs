using System;
using UnityEngine;

namespace Mechanics
{
    public class FloatBehaviour : MonoBehaviour
    {
        public event Action<float> OnEvent;
        public float Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnEvent?.Invoke(value);
            }
        }

        [SerializeField]
        private float value;

    }

}
