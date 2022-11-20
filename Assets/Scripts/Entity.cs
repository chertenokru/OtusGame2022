using System;
using UnityEngine;


namespace Components
{
    public class Entity : MonoBehaviour
    {

        [SerializeField]
        private MonoBehaviour[] components;

        public T Get<T>()
        {
            T result;
            if (!TryGet<T>(out result))
                throw new Exception($"Component of type {typeof(T).Name} is not found");
            return result;
        }

        public bool TryGet<T>(out T result)
        {
            for (int i = 0, count = components.Length; i < count; i++)
            {
                var component = components[i];
                if (component is T tresult)
                {
                    result = tresult;
                    return true;
                }
            }
            result = default;
            return false;
        }

    }
}