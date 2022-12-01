using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Mechanics
{
    public sealed class Vector3LerpForTimeTransormMechanics : MonoBehaviour
    {
        [SerializeField]
        private Vector3 start;
        [SerializeField]
        [Required]
        private Vector3 end;
        [SerializeField]
        [Required]
        private float time;
        [SerializeField]
        [Required]
        private Transform source;
        [SerializeField]
        [Required]



        public IEnumerator MoveCamera(Vector3 target)
        {
            var currentTime = 0f;
            var current = target;
            var end = new Vector3(current.x, current.y, current.z);
            var start = new Vector3(current.x, 1, 4f);

            while (currentTime < 6f)
            {
                target = Vector3.Lerp(start, end, currentTime / 6f);
                yield return null;
                currentTime += Time.deltaTime;
            }

        }


    }
}
