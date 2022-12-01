using Components.Interfaces;
using Const;
using Controllers.Interfaces;
using Entities;
using GameContext.Interfaces;
using Services.Interfaces;
using UnityEngine;

namespace Controllers
{
    public sealed class CollisionObserver : MonoBehaviour, ICollisionObserver, IConstructListener, IStartGameListener
    {
        [SerializeField]
        private float plaeyrDamageDelay = 1f;

        private IGameContext context;
        private IEffectController effectController;
        private float lastPlayerDamageTime = 0f;


        //todo разбить на куски, упорядочить, подумать об разных обработчиках событий от разных типов объектов
        private void OnContact(Collider owner, Collider other)
        {
            if(!other.TryGetComponent(out IEntity entityOther))
            {
                Debug.Log($"NOT ENTITY {other.name}");

            }
            if(!owner.TryGetComponent(out IEntity entityOwner))
            {
                Debug.Log($"NOT ENTITY {other.name}");

            }
            var typeOwnerValue = GameObjectType.None;
            if(entityOwner != null && entityOwner.TryGet(out IGetObjectTypeComponent typeOwner)) typeOwnerValue = typeOwner.GetObjectType();

            var typeOtherValue = GameObjectType.None;
            if(entityOther != null && entityOther.TryGet(out IGetObjectTypeComponent typeOther)) typeOtherValue = typeOther.GetObjectType();
            if(typeOtherValue == GameObjectType.None)
            {
                Debug.Log("Подозрительно");
            }
            Debug.Log($"Столкновение owner - {typeOwnerValue.ToString()}, второй - {typeOtherValue.ToString()} ");

            // ну типа победа (прибытие)
            if(typeOwnerValue == GameObjectType.Player && typeOtherValue == GameObjectType.FinishZone)
            {
                context.GetService<ICharacterService>().OnPlayerCollisionWithFinishZone(entityOther);
            };


            // todo Разбить потом по слоям, чтоб не было лишних столкновений
            if(typeOwnerValue == GameObjectType.Enemy &&
                (typeOtherValue == GameObjectType.Enemy ||
                 typeOtherValue == GameObjectType.EnemyBullet ||
                 typeOtherValue == GameObjectType.Bonus ||
                 typeOtherValue == GameObjectType.Resource)) return;
            // todo Разбить потом по слоям, чтоб не было лишних столкновений
            if(typeOwnerValue == GameObjectType.Player &&
                (typeOtherValue == GameObjectType.PlayerBullet ||
                 typeOtherValue == GameObjectType.ObjectLimiter)) return;

            if(typeOtherValue == GameObjectType.Player &&
                 (typeOwnerValue == GameObjectType.EnemyBullet || typeOwnerValue == GameObjectType.Enemy))
                if(Time.unscaledTime - lastPlayerDamageTime < plaeyrDamageDelay) return;
                else
                    lastPlayerDamageTime = Time.unscaledTime;

            if(typeOwnerValue == GameObjectType.Player &&
                (typeOtherValue == GameObjectType.EnemyBullet || typeOtherValue == GameObjectType.Enemy))
                if(Time.unscaledTime - lastPlayerDamageTime < plaeyrDamageDelay) return;
                else
                    lastPlayerDamageTime = Time.unscaledTime;


            // выход за границы
            if(typeOwnerValue == GameObjectType.ObjectLimiter)
            {
                if(entityOther != null && entityOther.TryGet(out IDeathComponent deathOther)) deathOther.Death();
            }
            // выход за границы
            if(typeOtherValue == GameObjectType.ObjectLimiter)
            {
                if(entityOwner != null && entityOwner.TryGet(out IDeathComponent deathOwner)) deathOwner.Death();
            }

            if(entityOwner != null && entityOther != null)
            {
                entityOwner.TryGet(out IGetDamageComponent damageFromOwner);
                entityOwner.TryGet(out ITakeDamageComponent takeDamageOwner);

                entityOther.TryGet(out IGetDamageComponent damageFromOther);
                entityOther.TryGet(out ITakeDamageComponent takeDamageOther);

                var damageFromOtherValue = 0;
                // урон от врага
                if(damageFromOther != null) damageFromOtherValue = damageFromOther.GetDamage();
                // урон врагу от нас, если мы его можем наносить, а враг принимать
                if((damageFromOwner != null) && (takeDamageOther != null))
                {
                    takeDamageOther.TakeDamage(damageFromOwner.GetDamage());
                    effectController.PlayExplosion(other.transform);
                }
                // урон нам, если мы можем его принимать, а враг наносить

                if((damageFromOtherValue > 0) && (takeDamageOwner != null))
                {
                    takeDamageOwner.TakeDamage(damageFromOtherValue);
                    effectController.PlayExplosion(owner.transform);
                }

                // пули всегда убиваем
                if(typeOtherValue == GameObjectType.PlayerBullet || typeOtherValue == GameObjectType.PlayerBullet)
                {
                    if(entityOther.TryGet(out IDeathComponent typeOtherDead)) typeOtherDead.Death();
                }
            }
        }

        public void AttachObject(ITriggerTwoColliderEventsComponent collisionTrigger)
        {
            collisionTrigger.OnEntered += OnContact;
        }
        public void Construct(IGameContext context)
        {
            this.context = context;
        }
        public void DeAttachObject(ITriggerTwoColliderEventsComponent collisionTrigger)
        {
            collisionTrigger.OnEntered -= OnContact;
        }
        public void OnStartGame()
        {
            effectController = context.GetService<EffectController>();
        }

    }
}
