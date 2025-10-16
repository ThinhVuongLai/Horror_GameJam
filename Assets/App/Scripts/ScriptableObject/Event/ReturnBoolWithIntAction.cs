using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReturnBoolWithIntAction", menuName = "ScriptableObject/ReturnBoolWithIntAction")]
public class ReturnBoolWithIntAction : ScriptableObject
{
    private System.Func<int, bool> func;

    public void ResignAction(System.Func<int, bool>func)
    {
        this.func += func;
    }

    public void UnResignAction(System.Func<int, bool> func)
    {
        this.func -= func;
    }

    public bool Invoke(int index)
    {
        if (func != null)
        {
            return func.Invoke(index);
        }
        return false;
    }
}
