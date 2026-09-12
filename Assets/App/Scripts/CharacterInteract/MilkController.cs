using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkController : MonoBehaviour, IInteractItem
{
    [SerializeField] private GameObject milkObject;

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to Get Milk");
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
        if(milkObject)
        {
            milkObject.SetActive(false);

            ScriptableObjectController.I.UpdateHasMilkAction.RunAction(true);
        }
    }

    public void UnInteract()
    {
        
    }
}
