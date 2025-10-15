using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlantController : MonoBehaviour, IInteractItem
{
    [SerializeField] private List<LeefController> leefControllers = new List<LeefController>();

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to Cut Plant");
        }
        else
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("");
        }
    }

    public void HoldInteract()
    {

    }

    public void Interact()
    {
        canInteract = false;

        ScriptableObjectController.I.SetLockCharacterAction.RunAction(true);

        StartCoroutine(CRCutPlant());
    }

    public void UnInteract()
    {

    }

    private IEnumerator CRCutPlant()
    {
        for (int i = 0; i < leefControllers.Count; i++)
        {
            leefControllers[i].DropLeef();
            yield return new WaitForSeconds(0.3f);
        }

        ScriptableObjectController.I.SetLockCharacterAction.RunAction(false);
    }
}
