using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{

    public enum RotateType
    {
        Auto, RotateXLeft, RotateXRight, RotateZForward, RotateZBack
    }
    public sealed class RotateMechanics_Auto : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private Transform[] moveTransforms;

        private RotateType rotateType;

        private Vector3 direct;

        private void Awake()
        {
            if(rotateType == RotateType.Auto)
                rotateType = (RotateType) UnityEngine.Random.Range(0, Enum.GetNames(typeof(RotateType)).Length);

            switch(rotateType)
            {
                case RotateType.RotateXLeft:
                    direct = Vector3.left;
                    break;
                case RotateType.RotateXRight:
                    direct = Vector3.right;
                    break;
                case RotateType.RotateZForward:
                    direct = Vector3.forward;
                    break;
                case RotateType.RotateZBack:
                    direct = Vector3.back;
                    break;
            }
        }

        private void FixedUpdate()
        {
            Rotate(direct);
        }


        private void Rotate(Vector3 direction)
        {
            foreach(var item in moveTransforms)
            {
                item.Rotate(direction);

            }
        }
    }

}