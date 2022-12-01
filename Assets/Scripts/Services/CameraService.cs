using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Services
{
    public sealed class CameraService : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private Transform cameraTransform;
        [SerializeField]
        [Required]
        private CinemachineVirtualCamera virtualCamera;

        public CinemachineVirtualCamera Camera { get { return virtualCamera; } }
        public Transform CameraTransform { get { return cameraTransform; } }

    }
}