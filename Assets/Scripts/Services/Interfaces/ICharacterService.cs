using Entities;

namespace Services.Interfaces
{
    public interface ICharacterService
    {
        public IEntity GetCharacter();
        public void OnPlayerCollisionWithFinishZone(IEntity entity);
    }
}