using Mechanics;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;



public class WeaponPanelAdapter : MonoBehaviour
{
    [SerializeField]
    [Required]
    private AttackWeaponMechanics weaponMechanics;
    [SerializeField]
    [Required]
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        weaponMechanics.OnWeaponChanged += OnWeaponChanged;
    }
    private void OnDisable()
    {
        weaponMechanics.OnWeaponChanged -= OnWeaponChanged;
    }

    private void OnWeaponChanged(BaseWeapoint value)
    {
        text.text = value.GetName();
    }
}
