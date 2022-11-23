
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private Vector3EventReceiver vector3EventSourceReceiver;

        [SerializeField]
        [Required]
        private Transform[] moveTransforms;

        [SerializeField]
        [Required]
        private FloatBehaviour speed;

        private void OnEnable()
        {
            vector3EventSourceReceiver.OnEvent += this.OnMove;
        }

        private void OnDisable()
        {
            vector3EventSourceReceiver.OnEvent -= this.OnMove;
        }

        private void OnMove(Vector3 moveVector)
        {
            foreach (var item in moveTransforms)
            {
                item.position += moveVector * speed.Value * Time.deltaTime;
            }
        }
    }
}
