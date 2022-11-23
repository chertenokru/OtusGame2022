using System;
using UnityEngine;

namespace Mechanics
{
    public class StringBehaviour : MonoBehaviour
    {
        public event Action<String> OnEvent;
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnEvent?.Invoke(value);
            }
        }

        [SerializeField]
        private string value;

    }

}
