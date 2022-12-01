using Const;

namespace GameContext.Interfaces
{
    public interface IGameContext
    {
        void ConstructGame();
        void StartGame();
        void FinishGame(GameFinishType result);
        void PauseGame();
        void ResumeGame();

        public T GetService<T>();
    }
}
