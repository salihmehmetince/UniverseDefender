using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public event EventHandler onShoot;

    public event EventHandler onTalk;

    public event EventHandler onChoose;

    public event EventHandler onWork;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Shoot.performed += shootPerformed;
        playerInputActions.Player.Talk.performed += talkPerformed;
        playerInputActions.Player.Choose.performed += onChoosePerformed;
        playerInputActions.Player.Work.performed += onWorkPerformed;
    }

    private void onWorkPerformed(InputAction.CallbackContext obj)
    {
        onWork?.Invoke(this,EventArgs.Empty);
    }

    private void onChoosePerformed(InputAction.CallbackContext obj)
    {
        onChoose?.Invoke(this,EventArgs.Empty);
    }

    private void talkPerformed(InputAction.CallbackContext obj)
    {
        onTalk?.Invoke(this,EventArgs.Empty);
    }
    private void shootPerformed(InputAction.CallbackContext obj)
    {
        onShoot?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 getMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }

    public int getChooseValue()
    {
        Vector2 chooseValue = playerInputActions.Player.Choose.ReadValue<Vector2>();
        chooseValue= chooseValue.normalized;
        int value = 0;
        if(chooseValue.y==1f)
        {
            value = 1;
        }
        else if(chooseValue.y == -1f)
        {
            value = 2;
        }
        else if (chooseValue.x == -1f)
        {
            value = 3;
        }
        else if (chooseValue.x == 1f)
        {
            value = 4;
        }
        return value;;
    }
}
