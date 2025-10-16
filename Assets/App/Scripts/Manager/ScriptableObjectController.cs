using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectController : SingletonMono<ScriptableObjectController>
{
    [Header("Action")]
    [SerializeField] private UpdateTextAction updateHighlightTextAction;
    [SerializeField] private UpdateTextAction updateDateTimeTextAction;

    [SerializeField] private UpdateBoolAction updateInteractingAction;
    [SerializeField] private UpdateBoolAction setLockCharacterAction;

    [SerializeField] private UpdateIntAction updateInventeryFoodIndexAction;

    [SerializeField] private UpdateStringAction updateInventeryTextAction;

    [SerializeField] private VoidAction cookAction;

    [Header("Return Action")]
    [SerializeField] private ReturnBoolWithIntAction hasCollectFoodAction;

    [SerializeField] private ReturnIntListAction getInventeryFoodIndexAction;

    public UpdateTextAction UpdateHighlightTextAction => updateHighlightTextAction;
    public UpdateTextAction UpdateDateTimeTextAction => updateDateTimeTextAction;
    public UpdateBoolAction UpdateInteractingAction => updateInteractingAction;
    public UpdateBoolAction SetLockCharacterAction => setLockCharacterAction;
    public UpdateIntAction UpdateInventeryFoodIndexAction => updateInventeryFoodIndexAction;
    public ReturnBoolWithIntAction HasCollectFoodAction => hasCollectFoodAction;
    public UpdateStringAction UpdateInventeryTextAction => updateInventeryTextAction;
    public ReturnIntListAction GetInventeryFoodIndexAction => getInventeryFoodIndexAction;
    public VoidAction CookAction => cookAction;
}
