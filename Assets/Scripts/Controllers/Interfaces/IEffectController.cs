using UnityEngine;

namespace Controllers.Interfaces
{

    public interface IEffectController
    {
        public void PlayExplosion(Transform coord);
        public void PlayExplosion(Vector3 coord);
        public void PlayDeath(Vector3 coord);
        public void PlayDeath(Transform coord);
    }
}