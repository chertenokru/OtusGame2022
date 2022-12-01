using Components.Interfaces;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Mechanics
{
    public sealed class CollisionMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver_Trigger collisionSourceReciver;
        [SerializeField]
        private IntBehaviour damage;
        [SerializeField]
        private IntEventReceiver damageTargetReciver;

        private void OnEnable()
        {
            collisionSourceReciver.OnTriggerEntered += OnContact;
        }

        private void OnDisable()
        {
            collisionSourceReciver.OnTriggerEntered -= OnContact;
        }


        private void OnContact(Collider other)
        {
            if(!other.TryGetComponent(out IEntity entity))
            {
                //    Debug.Log($"NOT ENTITY {other.name}");
                return;
            }

            entity.TryGet(out IGetDamageComponent damageFromOther);
            entity.TryGet(out ITakeDamageComponent takeDamageOther);

            var damageFromOtherValue = 0;
            // урон от врага
            if(damageFromOther != null) damageFromOtherValue = damageFromOther.GetDamage();
            // урон врагу от нас, если мы его можем наносить, а враг принимать
            if((damage != null) && (takeDamageOther != null)) takeDamageOther.TakeDamage(damage.Value);
            // урон нам, если мы можем его принимать, а враг наносить
            if((damageFromOtherValue > 0) && (damageTargetReciver != null)) damageTargetReciver.Call(damageFromOtherValue);

        }

    }
}
