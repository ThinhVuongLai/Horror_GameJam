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
    [SerializeField] private UpdateBoolAction updateHasDishAction;
    [SerializeField] private UpdateBoolAction updateHasMilkAction;

    [SerializeField] private UpdateIntAction updateInventeryFoodIndexAction;

    [SerializeField] private UpdateStringAction updateInventeryTextAction;

    [SerializeField] private VoidAction cookAction;
    [SerializeField] private VoidAction showLoseAction;
    [SerializeField] private VoidAction showFinishAction;

    [Header("Return Action")]
    [SerializeField] private ReturnBoolWithIntAction hasCollectFoodAction;

    [SerializeField] private ReturnBoolAction haveDishAction;
    [SerializeField] private ReturnBoolAction haveMilkAction;

    [SerializeField] private ReturnIntListAction getInventeryFoodIndexAction;

    public UpdateTextAction UpdateHighlightTextAction => updateHighlightTextAction;
    public UpdateTextAction UpdateDateTimeTextAction => updateDateTimeTextAction;
    public UpdateBoolAction UpdateInteractingAction => updateInteractingAction;
    public UpdateBoolAction SetLockCharacterAction => setLockCharacterAction;
    public UpdateBoolAction UpdateHasDishAction => updateHasDishAction;
    public UpdateBoolAction UpdateHasMilkAction => updateHasMilkAction;
    public UpdateIntAction UpdateInventeryFoodIndexAction => updateInventeryFoodIndexAction;
    public ReturnBoolWithIntAction HasCollectFoodAction => hasCollectFoodAction;
    public UpdateStringAction UpdateInventeryTextAction => updateInventeryTextAction;
    public ReturnIntListAction GetInventeryFoodIndexAction => getInventeryFoodIndexAction;
    public VoidAction CookAction => cookAction;
    public VoidAction ShowLoseAction => showLoseAction;
    public VoidAction ShowFinishAction => showFinishAction;

    public ReturnBoolAction HaveDishAction => haveDishAction;
    public ReturnBoolAction HaveMilkAction => haveMilkAction;
}
