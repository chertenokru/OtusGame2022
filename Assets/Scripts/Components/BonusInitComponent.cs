using Components.Interfaces;
using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Components
{
    public class BonusInitComponent : MonoBehaviour, IBonusInitComponent
    {
        [SerializeField]
        [Required]
        private IntEventReceiver bonusChangeTargetReceiver;

        public void Init(int bunusValue)
        {
            bonusChangeTargetReceiver.Call(bunusValue);
        }
    }
}
