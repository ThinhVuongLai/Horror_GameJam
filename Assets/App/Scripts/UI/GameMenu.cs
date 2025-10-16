using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("Date Time")]
    [SerializeField] private Text dateTimeText = null;

    [Header("Inventery")]
    [SerializeField] private Text inventeryItemText = null;

    private void OnEnable()
    {
        ScriptableObjectController.I.UpdateDateTimeTextAction.ResignAction(UpdateDateTimeText);
        ScriptableObjectController.I.UpdateInventeryTextAction.RegisterAction(UpdateInventeryText);
    }

    private void OnDisable()
    {
        ScriptableObjectController.I.UpdateDateTimeTextAction.UnResignAction(UpdateDateTimeText);
        ScriptableObjectController.I.UpdateInventeryTextAction.UnregisterAction(UpdateInventeryText);
    }

    private void UpdateDateTimeText(string textString)
    {
        if (dateTimeText != null)
        {
            dateTimeText.text = textString;
        }
    }

    public void UpdateInventeryText(string textString)
    {
        if (inventeryItemText != null)
        {
            inventeryItemText.text = textString;
        }
    }
}
