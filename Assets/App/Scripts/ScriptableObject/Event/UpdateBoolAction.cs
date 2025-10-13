using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpdateBoolAction", menuName = "ScriptableObject/UpdateBoolAction")]
public class UpdateBoolAction : ScriptableObject
{
    private System.Action<bool> action;

    public void ResignAction(System.Action<bool> newAction)
    {
        action += newAction;
    }

    public void UnResignAction(System.Action<bool> oldAction)
    {
        action -= oldAction;
    }

    public void RunAction(bool value)
    {
        action?.Invoke(value);
    }
}
