using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] private GameObject highlightObject = null;
    [SerializeField] private Text highlightText = null;

    [Header("Ratcast Setting")]
    [SerializeField] private float raycastDistance = 3.0f;

    private IInteractItem currentInteractItem = null;

    private Vector3 sendRaycastPosition = Vector3.zero;

    private bool hasInteractItem = false;
    private bool inHightlight = true;
    private bool isInteracting = false;

    private void Awake()
    {
        sendRaycastPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        UnHighlight();
    }

    private void OnEnable()
    {
        ScriptableObjectController.I.UpdateHighlightTextAction.ResignAction(UpdateHightlightText);
        ScriptableObjectController.I.UpdateInteractingAction.ResignAction(SetIsInteracting);
    }

    private void OnDisable()
    {
        ScriptableObjectController.I.UpdateHighlightTextAction.UnResignAction(UpdateHightlightText);
        ScriptableObjectController.I.UpdateInteractingAction.UnResignAction(SetIsInteracting);
    }

    private void Update()
    {
        SendRaycat();
    }

    private void SendRaycat()
    {
        Ray ray = Camera.main.ScreenPointToRay(sendRaycastPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            currentInteractItem = hit.collider.GetComponent<IInteractItem>();
            if (currentInteractItem != null && currentInteractItem.canInteract)
            {
                Hightlight();

                if (isInteracting)
                {
                    currentInteractItem.Interact();
                }
            }
            else
            {
                UnHighlight();
            }
        }
        else
        {
            UnHighlight();
        }
    }

    private void Hightlight()
    {
        if (inHightlight)
        {
            return;
        }
        inHightlight = true;

        if (currentInteractItem != null)
        {
            highlightObject.SetActive(true);
            currentInteractItem.Highlight();
            hasInteractItem = true;
        }
    }

    private void UnHighlight()
    {
        if (!inHightlight)
        {
            return;
        }
        inHightlight = false;

        isInteracting = false;

        hasInteractItem = false;

        if (currentInteractItem != null)
        {
            currentInteractItem.UnInteract();
            currentInteractItem = null;
        }

        highlightObject.SetActive(false);
    }

    private void UpdateHightlightText(string textString)
    {
        highlightText.text = textString;
    }

    private void SetIsInteracting(bool setValue)
    {
        isInteracting = setValue;
    }
}
