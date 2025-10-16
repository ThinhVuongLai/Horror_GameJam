using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReturnBoolAction", menuName = "ScriptableObject/ReturnBoolAction")]
public class ReturnBoolAction : ScriptableObject
{
    private System.Func<bool> func;

    
    public void ResignFunc(System.Func<bool> func)
    {
        this.func += func;
    }

    public void UnResignFunc(System.Func<bool> func)
    {
        this.func -= func;
    }

    public bool Invoke()
    {
        if (func != null)
        {
            return func.Invoke();
        }
        else
        {
            Debug.LogWarning("ReturnBoolAction: func is null");
            return false;
        }
    }
}
