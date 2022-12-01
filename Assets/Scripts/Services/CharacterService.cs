using Components.Interfaces;
using Controllers.Interfaces;
using Entities;
using GameContext.Interfaces;
using Services.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Services
{
    public sealed class CharacterService : MonoBehaviour, IConstructListener, IStartGameListener, ICharacterService
    {
        [SerializeField]
        [Required]
        private UnityEntity character;
        private IGameContext context;

        public void Construct(IGameContext context)
        {
            this.context = context;
        }

        public IEntity GetCharacter()
        {
            return character;
        }

        public void OnStartGame()
        {
            // подписываем плеера на столкновения
            context.GetService<ICollisionObserver>().AttachObject(character.Get<ITriggerTwoColliderEventsComponent>());
            // и подписываемся на его смерть
            character.Get<IOnDeathSubscriptionComponent>().OnDeath += OnDeadPlayer;
        }

        public void OnDeadPlayer(IEntity entity)
        {
            var pos = character.Get<IGetPositionComponent>().GetPosition();

            context.GetService<IEffectController>().PlayDeath(
                new Vector3(pos.x, pos.y, pos.z + 1));
            context.FinishGame(Const.GameFinishType.PlayerDead);
        }

        public void OnPlayerCollisionWithFinishZone(IEntity entity)
        {
            context.FinishGame(Const.GameFinishType.PlayerWin);
        }
    }
}