
using UnityEngine;

namespace Mechanics
{
    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField]
        private Vector3EventReceiver vector3EventSourceReceiver;

        [SerializeField]
        private Transform[] moveTransforms;

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
                item.position += moveVector;
            }
        }
    }
}
