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
        private IntBehaviour restoryDelayStart;
        [SerializeField]
        private IntBehaviour restoryDelayStep;
        [SerializeField]
        private TimerBehaviour timerDelayStart;
        [SerializeField]
        private TimerBehaviour timerRestoryDelayStep;

        private int lastValue;
        private int sign = 1;



        private void OnEnable()
            {
            checkSign(restoryStep.Value);
            currentValue.OnValueChanged += OnChangeValue;
            timerRestoryDelayStep.OnEnded += OnNextStep;
            timerDelayStart.OnEnded += OnNextStep;
            restoryStep.OnValueChanged += checkSign;
            lastValue = currentValue.Value;
            }


        private void OnDisable()
            {
            currentValue.OnValueChanged -= OnChangeValue;
            timerRestoryDelayStep.OnEnded -= OnNextStep;
            timerDelayStart.OnEnded -= OnNextStep;
            restoryStep.OnValueChanged -= checkSign;
            }


        private void OnChangeValue(int newValue)
            {

            if(newValue * sign < lastValue * sign && !timerDelayStart.IsPlaying)
                {
                timerDelayStart.Stop();
                timerRestoryDelayStep.Stop();
                timerDelayStart.Duration = restoryDelayStart.Value;
                timerDelayStart.ResetTime();
                timerDelayStart.Play();
                }
            lastValue = newValue;
            }

        private void OnNextStep()
            {
            if(currentValue.Value * sign >= endValue.Value * sign || timerDelayStart.IsPlaying) return;
            currentValue.Value += restoryStep.Value;
            timerRestoryDelayStep.Stop();
            timerRestoryDelayStep.Duration = restoryDelayStep.Value;
            timerRestoryDelayStep.ResetTime();
            timerRestoryDelayStep.Play();
            }


        private void checkSign(int value)
            {
            sign = value < 0 ? -1 : 1;
            }
        }

    }