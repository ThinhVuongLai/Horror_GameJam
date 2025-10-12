using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnApplicationFocus(bool isFocusGame)
    {
        SetCursorState(isFocusGame);
    }

    private void SetCursorState(bool isFocusGame)
    {
        Cursor.lockState = isFocusGame ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isFocusGame;
    }
}
