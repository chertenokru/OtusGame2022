
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{

    public sealed class RotateOnMoveMechanics : MonoBehaviour
    {

        [SerializeField]
        [Required]
        private Vector3EventReceiver vector3EventSourceReceiver;

        [SerializeField]
        [Required]
        private Transform[] moveTransforms;

        [SerializeField]
        [Required]
        private float angelRotate;

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
            var rotate = Vector3.zero;
            if (moveVector == Vector3.left)
                rotate.z = angelRotate;
            else if (moveVector == Vector3.right)
                rotate.z = -angelRotate;

            if (moveVector == Vector3.forward)
                rotate.x = angelRotate;
            else if (moveVector == Vector3.back)
                rotate.x = -angelRotate;

            foreach (var item in moveTransforms)
            {
                item.rotation = Quaternion.Euler(rotate);

            }
        }
    }
}
