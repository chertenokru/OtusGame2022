
using Controllers.Interfaces;
using UnityEngine;

namespace Controllers
{
    public sealed class PauseController : MonoBehaviour, IPauseGameListener, IResumeGameListener, IStartGameListener, IFinishGameListener
    {
        private const float PAUSE_SCALE = 0;

        private const float RESUME_SCALE = 1;

        public void OnFinishGame()
        {
            ResumeGame();
        }

        public void OnPauseGame()
        {
            PauseGame();
        }

        public void OnResumeGame()
        {
            ResumeGame();
        }

        public void OnStartGame()
        {
            ResumeGame();
        }

        private void PauseGame()
        {
            Time.timeScale = PAUSE_SCALE;
        }

        private void ResumeGame()
        {
            Time.timeScale = RESUME_SCALE;
        }
    }
}
