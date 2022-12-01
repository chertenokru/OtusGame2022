using UnityEngine;
namespace Mechanics
{
    public class RestoryIntMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntBehaviour endValue;
        [SerializeField]
        private IntBehaviour currentValue;
        [SerializeField]
        private IntBehaviour restoryStep;
        [SerializeField]
        private FloatBehaviour restoryDelayStart;
        [SerializeField]
        private FloatBehaviour restoryDelayStep;
        [SerializeField]
        private TimerBehaviour timerDelayStart;
        [SerializeField]
        private TimerBehaviour timerRestoryDelayStep;

        private int lastValue;
        private int sign = 1;

        private void OnEnable()
        {
            CheckSign(restoryStep.Value);
            currentValue.OnEvent += OnChangeValue;
            timerRestoryDelayStep.OnEnded += OnNextStep;
            timerDelayStart.OnEnded += OnNextStep;
            restoryStep.OnEvent += CheckSign;
            lastValue = currentValue.Value;
        }

        private void OnDisable()
        {
            timerDelayStart.Stop();
            timerRestoryDelayStep.Stop();
            restoryStep.OnEvent -= CheckSign;
            currentValue.OnEvent -= OnChangeValue;
            timerRestoryDelayStep.OnEnded -= OnNextStep;
            timerDelayStart.OnEnded -= OnNextStep;
            restoryStep.OnEvent -= CheckSign;
        }

        private void OnChangeValue(int newValue)
        {
            if (newValue * sign < lastValue * sign && newValue != 0)
            {
                timerDelayStart.Stop();
                timerRestoryDelayStep.Stop();
                timerRestoryDelayStep.ResetTime();
                timerDelayStart.Duration = restoryDelayStart.Value;
                timerDelayStart.ResetTime();
                timerDelayStart.Play();
            }
            lastValue = newValue;
        }
        private void OnNextStep()
        {
            if (currentValue.Value * sign >= endValue.Value * sign || timerDelayStart.IsPlaying) return;
            currentValue.Value += restoryStep.Value;
            timerRestoryDelayStep.Stop();
            timerRestoryDelayStep.Duration = restoryDelayStep.Value;
            timerRestoryDelayStep.ResetTime();
            timerRestoryDelayStep.Play();
        }

        private void CheckSign(int value)
        {
            sign = value < 0 ? -1 : 1;
        }
    }
}