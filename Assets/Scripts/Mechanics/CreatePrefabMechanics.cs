using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class CreatePrefabMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver createSourceReciver;
        [SerializeField]
        [Required]
        private GameObject prefab;
        [SerializeField]
        [Required]
        private Transform createPosition;

        private void OnEnable()
        {
            createSourceReciver.OnEvent += OnCreate;
        }
        private void OnDisable()
        {
            createSourceReciver.OnEvent -= OnCreate;
        }

        void OnCreate()
        {
            Instantiate(prefab, createPosition.position, Quaternion.identity);
        }
    }
}
