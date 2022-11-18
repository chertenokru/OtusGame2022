
using Mechanics;
using UnityEngine;

public class Bullet : MonoBehaviour
    {
    [SerializeField]
    private EventReceiver deathTargetReceiver;
    [SerializeField]
    private IntBehaviour damage;

    public int Damage { get { return damage.Value; } }
    public void Destroy()
        {
        deathTargetReceiver.Call();
        }

    }
