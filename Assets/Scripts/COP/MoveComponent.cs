using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField]
        [Required]
        private Vector3EventReceiver receiver;
        [SerializeField]
        [Required]
        private IntBehaviour speed;
        public void Move(Vector3 vector)
        {
            receiver.Call(vector);
        }

        public int GetSpeed()
        {
            return speed.Value;
        }
    }
}
