using Const;

namespace Controllers.Interfaces
{
    public interface IFinishGameResultListener
    {
        void OnFinishResultGame(GameFinishType result);
    }
}