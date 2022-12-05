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

        private void FixedUpdate()
        {
            Move();
        }


        private void Move()
        {
            Vector3 direction;

            switch(moveType)
            {
                case MoveType.Forward:
                    direction = Vector3.forward;
                    break;
                case MoveType.Up:
                    direction = Vector3.up;
                    break;
                case MoveType.Circle:
                    //Move(new Vector3(Mathf.Sin(Time.timeScale * speed.Value), 0, Mathf.Cos(Time.deltaTime * speed.Value)));
                    direction = new Vector3(Mathf.Cos(Time.time) * amplitude.Value, Mathf.Sin(Time.time * frequency.Value) * amplitude.Value, 0);
                    break;
                case MoveType.Back:
                    direction = Vector3.back;
                    break;
                default:
                    return;
            }
            direction *= (speed.Value * Time.fixedDeltaTime);
            foreach(var item in moveTransforms)
            {
                item.position += direction;
            }
        }
    }

}