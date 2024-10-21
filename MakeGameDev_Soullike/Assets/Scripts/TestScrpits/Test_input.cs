using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Test_input : MonoBehaviour
{
    private PlayerInput playerInput = null;

    private InputAction moveAction = null;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += ReadAction;

        moveAction = playerInput.currentActionMap.FindAction("Move");
    }

    private void Update()
    {
        OnMove(moveAction.ReadValue<Vector2>());
    }

    public void ReadAction(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.action == moveAction)
        {
            OnMove(moveAction.ReadValue<Vector2>());
        }
    }
   
    public void OnFire()
    {
        Debug.Log("OnFire");
    }

    public void OnMove(Vector2 _value)
    {
        Vector2 move = _value;
        Debug.Log($"OnMove : {move.x}, {move.y}");
    }

}
