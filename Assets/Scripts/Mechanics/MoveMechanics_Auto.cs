using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{

    public enum MoveType
    {
        Forward, Circle
    }
    public sealed class MoveMechanics_Auto : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private Transform transformTarget;
        [SerializeField]
        [Required]
        private IntBehaviour speed;
        [SerializeField]
        private MoveType moveType;

        private void Update()
        {
            switch (moveType)
            {
                case MoveType.Forward:
                    Move(Vector3.forward * speed.Value * Time.deltaTime);
                    break;
                case MoveType.Circle:
                    Move(new Vector3(Mathf.Sin(Time.time * speed.Value) * 3, 0, Mathf.Cos(Time.time * speed.Value) * 3));
                    break;
            }
        }


        private void Move(Vector3 direction)
        {
            transformTarget.position += direction * (speed.Value * Time.deltaTime);
        }
    }

}