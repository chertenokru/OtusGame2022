using Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

public class Enemy : MonoBehaviour
    {
    [SerializeField]
    private IntEventReceiver takeDamageTargetReceiver;

    [Button]
    public void TakeDamage(int damage)
        {
        takeDamageTargetReceiver.Call(damage);
        }

    }
