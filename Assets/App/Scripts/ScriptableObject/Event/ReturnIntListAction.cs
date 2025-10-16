using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReturnIntListAction", menuName = "ScriptableObject/ReturnIntListAction")]
public class ReturnIntListAction : ScriptableObject
{
    private System.Func<List<int>> func;

    public void ResignAction(System.Func<List<int>> func)
    {
        this.func += func;
    }

    public void UnResignAction(System.Func<List<int>> func)
    {
        this.func -= func;
    }

    public List<int> RunAction()
    {
        if (func != null)
        {
            return func();
        }
        else
        {
            return new List<int>();
        }
    }
}
