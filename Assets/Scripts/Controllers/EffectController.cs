using Components.Interfaces;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Controllers
{
    public sealed class EffectController : MonoBehaviour, IEffectController, IConstructListener, IStartGameListener, IFinishGameListener
    {
        [SerializeField]
        [Required]
        private GameObject explosion;
        [SerializeField]
        [Required]
        private GameObject death;

        private IGameContext context;
        private IGetPositionComponent position;

        public void PlayExplosion(Transform coord)
        {
            Destroy(Instantiate(explosion, coord), 2);
        }
        public void PlayDeath(Vector3 coord)
        {
            Destroy(Instantiate(death, coord, Quaternion.identity), 2);
        }

        public void Construct(IGameContext context)
        {
            this.context = context;
        }

        public void OnFinishGame()
        {
        }

        public void OnStartGame()
        {

        }

        public void PlayExplosion(Vector3 coord)
        {
            Destroy(Instantiate(explosion, coord, Quaternion.identity), 2);
        }

        public void PlayDeath(Transform coord)
        {
            Destroy(Instantiate(death, coord), 2);
        }
    }
}
