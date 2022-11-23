using Mechanics;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;



public class BonusViewController : MonoBehaviour
{
    [SerializeField]
    [Required]
    private StringBehaviour textBonus;
    [SerializeField]
    [Required]
    private TextMeshProUGUI text;


    private void OnEnable()
    {
        textBonus.OnEvent += OnBonusChanged;
        OnBonusChanged(textBonus.Value);
    }
    private void OnDisable()
    {
        textBonus.OnEvent -= OnBonusChanged;
    }

    private void OnBonusChanged(string value)
    {
        text.text = value;
    }

}
