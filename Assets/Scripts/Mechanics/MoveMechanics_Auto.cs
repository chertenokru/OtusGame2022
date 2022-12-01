using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{

    public enum MoveType
    {
        Forward, Circle, Up, Back
    }
    public sealed class MoveMechanics_Auto : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private Transform[] moveTransforms;
        [SerializeField]
        [Required]
        private IntBehaviour speed;
        [SerializeField]
        [Required]
        private FloatBehaviour frequency;
        [SerializeField]
        [Required]
        private FloatBehaviour amplitude;
        [SerializeField]
        private MoveType moveType;

        private void Update()
        {
            switch (moveType)
            {
                case MoveType.Forward:
                    Move(Vector3.forward * speed.Value * Time.deltaTime);
                    break;
                case MoveType.Up:
                    Move(Vector3.up * speed.Value * Time.deltaTime);
                    break;
                case MoveType.Circle:
                    //Move(new Vector3(Mathf.Sin(Time.timeScale * speed.Value), 0, Mathf.Cos(Time.deltaTime * speed.Value)));
                    Move(new Vector3(Mathf.Cos(Time.time * frequency.Value) * amplitude.Value, Mathf.Sin(Time.time * frequency.Value) * amplitude.Value, 0) * Time.deltaTime);
                    break;
                case MoveType.Back:
                    Move(Vector3.back * speed.Value * Time.deltaTime);
                    break;

            }
        }


        private void Move(Vector3 direction)
        {
            foreach (var item in moveTransforms)
            {
                item.position += direction;
            }
        }
    }

}