using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpdateStringAction", menuName = "ScriptableObject/UpdateStringAction")]
public class UpdateStringAction : ScriptableObject
{
    private System.Action<string> action;

    public void RegisterAction(System.Action<string> act) { action += act; }

    public void UnregisterAction(System.Action<string> act) { action -= act; }

    public void RunAction(string str) { action?.Invoke(str); }
}
