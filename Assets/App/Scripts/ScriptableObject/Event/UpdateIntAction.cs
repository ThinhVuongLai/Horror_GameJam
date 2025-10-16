using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpdateIntAction", menuName = "ScriptableObject/UpdateIntAction")]
public class UpdateIntAction : ScriptableObject
{
    private System.Action<int> action;

    public void ResignAction(System.Action<int> action)
    {
        this.action += action;
    }

    public void UnResignAction(System.Action<int> action)
    {
        this.action -= action;
    }

    public void RunAction(int value)
    {
        action?.Invoke(value);
    }
}
