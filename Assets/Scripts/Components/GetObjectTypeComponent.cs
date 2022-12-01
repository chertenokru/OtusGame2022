using Components.Interfaces;
using Const;
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class GetObjectTypeComponent : MonoBehaviour, IGetObjectTypeComponent
    {
        [SerializeField]
        [Required]
        private GameObjectTypeBehaviour objectType;

        public GameObjectType GetObjectType()
        {
            return objectType.Value;
        }


    }
}
