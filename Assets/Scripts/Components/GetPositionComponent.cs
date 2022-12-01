using Components.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class GetPositionComponent : MonoBehaviour, IGetPositionComponent
    {
        [SerializeField]
        [Required]
        private Transform targetTransform;

        public Vector3 GetPosition()
        {
            return targetTransform.position;
        }

    }
}
