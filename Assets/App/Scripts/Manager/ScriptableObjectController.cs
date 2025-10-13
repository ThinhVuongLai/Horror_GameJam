using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectController : MonoBehaviour
{
    [Header("Action")]
    public static ScriptableObjectController instance;

    [SerializeField] private UpdateTextAction updateHighlightTextAction;

    [SerializeField] private UpdateBoolAction updateInteractingAction;

    public UpdateTextAction UpdateHighlightTextAction => updateHighlightTextAction;
    public UpdateBoolAction UpdateInteractingAction => updateInteractingAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
