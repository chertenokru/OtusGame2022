
using UnityEngine;

namespace Mechanics
    {
    public sealed class MoveMechanics : MonoBehaviour
        {
        [SerializeField]
        private Vector3EventReceiver vector3EventSourceReceiver;

        [SerializeField]
        private Transform moveTransform;

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
            moveTransform.position += moveVector;
            }
        }
    }
