using Const;
using Controllers.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

public class StateManager : MonoBehaviour, IStartGameListener, IFinishGameResultListener, IResumeGameListener, IPauseGameListener
{
    [SerializeField]
    [Required]
    private GameObject rootWintUI;
    [SerializeField]
    [Required]
    private GameObject rootLoseUI;
    [SerializeField]
    [Required]
    private GameObject rootPauseUI;


    public void OnStartGame()
    {
        rootLoseUI.SetActive(false);
        rootWintUI.SetActive(false);
        rootPauseUI.SetActive(false);
    }

    public void OnFinishResultGame(GameFinishType result)
    {
        rootPauseUI?.SetActive(false);
        if(result == GameFinishType.PlayerWin) rootWintUI.SetActive(true);
        else rootLoseUI.SetActive(true);
    }

    public void OnPauseGame()
    {
        rootPauseUI?.SetActive(true);
    }

    public void OnResumeGame()
    {
        rootPauseUI?.SetActive(false);
    }
}
