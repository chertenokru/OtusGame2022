using Components.Interfaces;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class BaseBulletWeapoint : BaseWeapoint
    {
        [SerializeField]
        [Required]
        private GameObject bullet;
        [SerializeField]
        [Required]
        private Transform[] createPosition;
        [SerializeField]
        [Required]
        private IntBehaviour attackDamage;
        [SerializeField]
        [Required]
        private string weaponName;


        public override void Attack()
        {
            foreach(Transform t in createPosition)
            {
                var newBullet = Instantiate(bullet, t.position, Quaternion.identity);

                if(newBullet.TryGetComponent(out IEntity entity))
                {
                    entity.TryGet(out ISetDamageComponent setDamageBullet);
                    setDamageBullet.SetDamage(attackDamage.Value);
                }
            }
        }

        public override string GetName()
        {
            return $"{weaponName} ({createPosition.Length.ToString()}шт. X {attackDamage.Value.ToString()}урон )";
        }
    }
}
