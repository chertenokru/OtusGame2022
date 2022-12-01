using Sirenix.OdinInspector;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UITimerCounter : MonoBehaviour
{
    [SerializeField]
    [Required]
    private int counter;
    [SerializeField]
    [Required]
    private int counterIdleSecond;
    [SerializeField]
    [Required]
    private TextMeshProUGUI label;
    [SerializeField]
    [Required]
    private bool isCountdown;

    public bool IsPlaying
    {
        get { return start; }
    }

    public event Action OnEnded;
    public event Action<int> OnStep;

    private Coroutine timerCoroutine;
    private bool start;


    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void startTimer()
    {
        if(!start) timerCoroutine = StartCoroutine(TimerRoutine(counter));
    }

    private IEnumerator TimerRoutine(int time)
    {
        var begin = isCountdown ? time : 1;
        var end = isCountdown ? 0 : time + 1;
        var step = isCountdown ? -1 : 1;
        start = true;

        for(int i = begin; (isCountdown && i > end) || (!isCountdown && i < end); i = i + step)
        {
            label.text = i.ToString();
            yield return new WaitForSeconds(counterIdleSecond);
            this.OnStep?.Invoke(i);
        }
        start = false;
        this.OnEnded?.Invoke();
    }



}
