using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UpdateTextAction", menuName = "ScriptableObject/UpdateTextAction")]
public class UpdateTextAction : ScriptableObject
{
    private System.Action<string> updateTextAction;

    public void ResignAction(System.Action<string> action)
    {
        updateTextAction += action;
    }

    public void UnResignAction(System.Action<string> action)
    {
        updateTextAction -= action;
    }

    public void RunAction(string text)
    {
        updateTextAction?.Invoke(text);
    }
}
