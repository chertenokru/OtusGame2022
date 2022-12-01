
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{
    [Serializable]
    public struct LimitedOxis
    {
        public bool IsLimited;
        public float min;
        public float max;
    }

    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField]
        private LimitedOxis LimitedOxisX;
        [SerializeField]
        private LimitedOxis LimitedOxisY;
        [SerializeField]
        private LimitedOxis LimitedOxisZ;
        [SerializeField]
        private Transform limitedTransform;

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
            var newPos = moveVector * (speed.Value * Time.deltaTime);
            var limitedPos = limitedTransform.position;
            if (LimitedOxisX.IsLimited) if ((limitedPos.x + newPos.x < LimitedOxisX.min) || (limitedPos.x + newPos.x > LimitedOxisX.max)) newPos.x = 0;
            if (LimitedOxisY.IsLimited) if ((limitedPos.y + newPos.y < LimitedOxisY.min) || (limitedPos.y + newPos.y > LimitedOxisX.max)) newPos.y = 0;
            if (LimitedOxisZ.IsLimited) if ((limitedPos.z + newPos.z < LimitedOxisZ.min) || (limitedPos.z + newPos.z > LimitedOxisX.max)) newPos.z = 0;
            foreach (var item in moveTransforms)
            {
                item.position += newPos;
            }
        }
    }
}
