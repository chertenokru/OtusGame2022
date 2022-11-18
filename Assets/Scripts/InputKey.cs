using Mechanics;
using System;
using UnityEngine;
public class InputKey : MonoBehaviour
    {
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;
    [SerializeField]
    private KeyCode top;
    [SerializeField]
    private KeyCode bottom;
    [SerializeField]
    private KeyCode jump;
    [SerializeField]
    private KeyCode fire;
    [SerializeField]
    private GameInputActionEventReceiver inputTargetReceiver;

    public Action<GameInputAction> Action;

    private void Update()
        {
        if(Input.GetKey(left)) inputTargetReceiver.Call(GameInputAction.Left);
        if(Input.GetKey(right)) inputTargetReceiver.Call(GameInputAction.Right);
        if(Input.GetKey(top)) inputTargetReceiver.Call(GameInputAction.Top);
        if(Input.GetKey(bottom)) inputTargetReceiver.Call(GameInputAction.Bottom);
        if(Input.GetKey(jump)) inputTargetReceiver.Call(GameInputAction.Jump);
        if(Input.GetKey(fire)) inputTargetReceiver.Call(GameInputAction.Fire);
        }



    }
