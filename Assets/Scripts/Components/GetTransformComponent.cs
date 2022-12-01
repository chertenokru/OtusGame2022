using Components.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class GetTransformComponent : MonoBehaviour, IGetTransformComponent
    {
        [SerializeField]
        [Required]
        private Transform targetTransform;

        public Transform GetTransform()
        {
            return targetTransform;
        }
    }
}
