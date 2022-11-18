using UnityEngine;

namespace Mechanics
    {
    public sealed class DestroyMechanics : MonoBehaviour
        {
        [SerializeField]
        private GameObject target;
        [SerializeField]
        private EventReceiver deathSourceReceiver;
        [SerializeField]
        public bool DontDestroy;

        private void OnEnable()
            {
            deathSourceReceiver.OnEvent += SelfDestroy;
            }

        private void OnDisable()
            {
            deathSourceReceiver.OnEvent -= SelfDestroy;
            }

        public void SelfDestroy()
            {

            if(target)
                if(DontDestroy)
                    target.SetActive(false);
                else Destroy(target);
            }
        }
    }
