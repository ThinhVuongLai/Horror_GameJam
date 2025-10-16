using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VoidAction", menuName ="ScriptableObject/VoidAction")]
public class VoidAction : ScriptableObject
{
    private System.Action action;

    public void ResignAction(System.Action action)
    {
        this.action += action;
    }

    public void UnResignAction(System.Action action)
    {
        this.action -= action;
    }

    public void RunAction()
    {
        action?.Invoke();
    }
}
