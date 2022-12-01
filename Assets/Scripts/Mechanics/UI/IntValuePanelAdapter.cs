using Mechanics;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;



public class IntValuePanelAdapter : MonoBehaviour
{
    [SerializeField]
    [Required]
    private IntBehaviour currentValue;
    [SerializeField]
    [Required]
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        currentValue.OnEvent += OnHPChanged;
        OnHPChanged(currentValue.Value);
    }
    private void OnDisable()
    {
        currentValue.OnEvent -= OnHPChanged;
    }

    private void OnHPChanged(int value)
    {
        text.text = value.ToString();
    }
}
