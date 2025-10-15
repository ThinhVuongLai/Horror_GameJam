using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("Date Time")]
    [SerializeField] private Text dateTimeText = null;

    private void OnEnable()
    {
        ScriptableObjectController.I.UpdateDateTimeTextAction.ResignAction(UpdateDateTimeText);
    }

    private void OnDisable()
    {
        ScriptableObjectController.I.UpdateDateTimeTextAction.UnResignAction(UpdateDateTimeText);
    }

    private void UpdateDateTimeText(string textString)
    {
        if (dateTimeText != null)
        {
            dateTimeText.text = textString;
        }
    }
}
