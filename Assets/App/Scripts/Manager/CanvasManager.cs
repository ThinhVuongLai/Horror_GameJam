using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private StartMenu StartMenu;
    [SerializeField] private LoseMenu LoseMenu;
    [SerializeField] private FinishMenu FinishMenu;

    private void Awake()
    {
        LoseMenu.gameObject.SetActive(false);
        FinishMenu.gameObject.SetActive(false);

        StartMenu.gameObject.SetActive(true);
        GameManager.I.SetPauseGame(true);
    }

    private void OnEnable()
    {
        ScriptableObjectController.I.ShowLoseAction.ResignAction(ShowLoseMenu);
        ScriptableObjectController.I.ShowFinishAction.ResignAction(ShowFinishAction);
    }

    private void OnDisable()
    {
        ScriptableObjectController.I.ShowLoseAction.UnResignAction(ShowLoseMenu);
        ScriptableObjectController.I.ShowFinishAction.UnResignAction(ShowFinishAction);
    }

    private void ShowLoseMenu()
    {
        LoseMenu.gameObject.SetActive(true);
    }

    private void ShowFinishAction()
    {
        FinishMenu.gameObject.SetActive(true);
    }
}
