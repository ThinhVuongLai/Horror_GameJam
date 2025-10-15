using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectController : SingletonMono<ScriptableObjectController>
{
    [Header("Action")]
    [SerializeField] private UpdateTextAction updateHighlightTextAction;
    [SerializeField] private UpdateTextAction updateDateTimeTextAction;

    [SerializeField] private UpdateBoolAction updateInteractingAction;

    public UpdateTextAction UpdateHighlightTextAction => updateHighlightTextAction;
    public UpdateTextAction UpdateDateTimeTextAction => updateDateTimeTextAction;
    public UpdateBoolAction UpdateInteractingAction => updateInteractingAction;
}
