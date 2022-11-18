using UnityEngine;



namespace Mechanics
    {

    public enum MoveType
        {
        Forward, Circle
        }
    public sealed class MoveAutoMechanics : MonoBehaviour
        {
        [SerializeField]
        private Vector3EventReceiver vector3EventTargetReceiver;
        [SerializeField]
        private IntBehaviour speed;
        [SerializeField]
        private MoveType moveType;




        private void OnEnable()
            {

            }

        private void OnDisable()
            {

            }


        private void Update()
            {
            switch(moveType)
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
            vector3EventTargetReceiver.Call((direction * (speed.Value * Time.deltaTime)));
            }
        }

    }