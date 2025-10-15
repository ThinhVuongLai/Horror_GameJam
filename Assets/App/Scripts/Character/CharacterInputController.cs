using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInputController : MonoBehaviour
{
    private Vector2 move = Vector2.zero;
    private Vector2 look = Vector2.zero;

    public Vector2 Move => move;
    public Vector2 Look => look;

    public void OnMove(InputValue inputValue)
    {
        SetMove(inputValue.Get<Vector2>());
    }

    public void OnLook(InputValue inputValue)
    {
        SetLook(inputValue.Get<Vector2>());
    }

    public void OnInteract(InputValue inputValue)
    {
        SetInteract(inputValue.isPressed);
    }

    private void SetMove(Vector2 moveDirect)
    {
        move = moveDirect;
    }

    private void SetLook(Vector2 lookDirect)
    {
        look = lookDirect;
    }

    private void SetInteract(bool isInteracting)
    {
        ScriptableObjectController.I.UpdateInteractingAction.RunAction(isInteracting);
    }
}
