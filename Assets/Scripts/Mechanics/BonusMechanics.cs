using Components.Interfaces;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics
{
    public sealed class BonusMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private IntEventReceiver setBonusValueEventSourceReceiver;
        [SerializeField]
        [Required]
        private IntBehaviour bonusValue;
        [SerializeField]
        [Required]
        private StringBehaviour bonusText;
        [SerializeField]
        [Required]
        private EventReceiver_Trigger eventSourceTrigger;
        [SerializeField]
        [Required]
        private EventReceiver eventDeathTarget1Trigger;
        [SerializeField]
        [Required]
        private EventReceiver eventDeathTarget2Trigger;
        [SerializeField]
        [Required]
        private TimerBehaviour timer;
        [SerializeField]
        [Required]
        private MoveMechanics_Auto moveMechanics_Auto;


        private void OnEnable()
        {
            bonusValue.Value = Random.Range(1, 4);
            setBonusValueEventSourceReceiver.OnEvent += OnSetBonus;
            eventSourceTrigger.OnTriggerEntered += OnCollision;
            timer.OnEnded += () => { eventDeathTarget2Trigger.Call(); };
        }

        private void OnDisable()
        {
            setBonusValueEventSourceReceiver.OnEvent -= OnSetBonus;
            eventSourceTrigger.OnTriggerEntered -= OnCollision;
        }

        private void OnSetBonus(int value)
        {
            bonusValue.Value = value;
        }

        private void OnCollision(Collider otherCollider)
        {
            if(!otherCollider.TryGetComponent(out IEntity entity))
            {
                return;
            }

            entity.TryGet(out ISetDamageComponent setDamageComp);
            entity.TryGet(out IAttackComponent attackComp);

            // если умеет атаковать и поддерживает изменение дамага
            if(setDamageComp != null && attackComp != null)
            {
                setDamageComp.SetDamage(bonusValue.Value);
                bonusText.Value = bonusValue.Value.ToString();
                eventDeathTarget1Trigger.Call();
                moveMechanics_Auto.enabled = true;
                timer.Play();
            }



        }
    }
}
