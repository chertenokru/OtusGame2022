using Mechanics;
using Sirenix.OdinInspector;
using System.Collections;
using TMPro;
using UnityEngine;



public class HPViewController : MonoBehaviour
{
    [SerializeField]
    [Required]
    private IntBehaviour hp;
    [SerializeField]
    [Required]
    private TextMeshProUGUI text;
    [SerializeField]
    [Required]
    private Material materialMunis;
    [SerializeField]
    [Required]
    private Material materialPlus;
    [SerializeField]
    [Required]
    private MeshRenderer ObjRenderer;
    [SerializeField]
    private float delayChangeColor = 0.1f;
    private Coroutine timerCoroutine;
    private Material materialTemp;
    private bool start;
    private int oldValue = 0;

    private void OnEnable()
    {
        hp.OnEvent += OnHPChanged;
        OnHPChanged(hp.Value);
    }
    private void OnDisable()
    {
        hp.OnEvent -= OnHPChanged;
        StopAllCoroutines();
    }

    private void OnHPChanged(int hp)
    {
        text.text = hp.ToString();
        if(!start) timerCoroutine = StartCoroutine(TimerRoutine(hp));
    }

    private IEnumerator TimerRoutine(int hp)
    {
        start = true;
        materialTemp = ObjRenderer.material;
        if(oldValue != 0) ObjRenderer.material = (hp > oldValue) ? materialPlus : materialMunis;
        yield return new WaitForSeconds(delayChangeColor);
        ObjRenderer.material = materialTemp;
        oldValue = hp;
        start = false;
    }



}
