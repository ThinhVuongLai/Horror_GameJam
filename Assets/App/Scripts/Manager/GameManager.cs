using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    private bool isPause = false;

    public bool IsPause => isPause;

    private void OnApplicationFocus(bool isFocusGame)
    {
        SetCursorState(isFocusGame);
    }

    public void SetCursorState(bool isFocusGame)
    {
        Cursor.lockState = isFocusGame ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !isFocusGame;
    }

    public void SetPauseGame(bool isPause)
    {
        TimeManager.I.IsRunTime = isPause;
    }
}
