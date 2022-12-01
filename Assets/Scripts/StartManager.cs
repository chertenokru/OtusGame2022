using Services.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    [Required]
    private Controllers.GameContext context;
    [SerializeField]
    [Required]
    private UITimerCounter timer;
    [SerializeField]
    [Required]
    private GameObject rootStartUI;
    [SerializeField]
    [Required]
    private GameObject rootGameUI;
    [SerializeField]
    [Required]
    private bool skipIntro;

    private ICameraTransformService cameraMain;


    private void OnEnable()
    {
        rootGameUI.SetActive(false);
        rootStartUI.SetActive(false);
        timer.OnEnded += DisableUI;
    }

    void Start()
    {
        context.ConstructGame();

        cameraMain = context.GetService<ICameraTransformService>();
        if(skipIntro)
        {
            ContinueStart();
            return;
        }

        rootStartUI.SetActive(true);
        timer.startTimer();
        cameraMain.CurrentPostionEnd = true;
        cameraMain.StartPosition = new Vector3(0, 1, 4);
        cameraMain.TimeToPlay = 6;
        cameraMain.OnEnd += ContinueStart;
        cameraMain.Play();
    }

    private void ContinueStart()
    {
        cameraMain.OnEnd -= ContinueStart;
        rootGameUI?.SetActive(true);
        context.StartGame();
    }

    private void DisableUI()
    {
        rootStartUI.SetActive(false);
    }

}
