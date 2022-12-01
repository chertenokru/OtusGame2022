
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public sealed class GameContextInstaller : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private GameContext context;

        [Space]
        [SerializeField]
        private MonoBehaviour[] listeners;

        [Space]
        [SerializeField]
        private MonoBehaviour[] services;
        private void Awake()
        {
            foreach (var listener in listeners)
            {
                context.AddListener(listener);
            }
            foreach (var service in services)
            {
                context.AddService(service);
            }
        }
    }
}
