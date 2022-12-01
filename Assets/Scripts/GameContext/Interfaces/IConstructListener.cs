using GameContext.Interfaces;

namespace Controllers.Interfaces
{
    public interface IConstructListener
    {
        void Construct(IGameContext context);
    }
}
