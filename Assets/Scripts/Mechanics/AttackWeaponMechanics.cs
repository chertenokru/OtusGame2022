using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Mechanics
{
    public sealed class AttackWeaponMechanics : MonoBehaviour
    {
        [SerializeField]
        [Required]
        private EventReceiver fireSourceReciver;
        [SerializeField]
        [Required]
        private EventReceiver changeWeaponSourceReciver;
        [SerializeField]
        [Required]
        private TimerBehaviour delay;
        [SerializeField]
        [Required]
        private BaseWeapoint weapon;
        [SerializeField]
        [Required]
        private BaseWeapoint[] weapons;

        private int currentIndexWeapon;

        public event Action<BaseWeapoint> OnWeaponChanged;
        void Attack()
        {
            if (!delay.IsPlaying)
            {
                weapon.Attack();
                delay.ResetTime();
                delay.Play();
            }
        }

        public void NextWeapon()
        {
            if (weapons?.Length > 1)
            {
                if (currentIndexWeapon == weapons.Length - 1) currentIndexWeapon = 0; else currentIndexWeapon += 1;
                weapon = weapons[currentIndexWeapon];
                OnWeaponChanged?.Invoke(weapon);
            }
        }

        private void OnEnable()
        {
            fireSourceReciver.OnEvent += Attack;
            changeWeaponSourceReciver.OnEvent += NextWeapon;
            OnWeaponChanged?.Invoke(weapon);
            if (weapons?.Length > 1) { }
            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] == weapon)
                {
                    currentIndexWeapon = i;
                    return;
                }
            }
        }
        private void OnDisable()
        {
            fireSourceReciver.OnEvent -= Attack;
            changeWeaponSourceReciver.OnEvent -= NextWeapon;
        }
    }
}
