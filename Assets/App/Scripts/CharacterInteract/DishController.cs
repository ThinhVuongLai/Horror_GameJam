using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishController : MonoBehaviour, IInteractItem
{
    [SerializeField] private GameObject dishObject = null;

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to Get Dish");
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
        //canInteract = false;

        if(dishObject)
        {
            dishObject.SetActive(false);

            ScriptableObjectController.I.UpdateHasDishAction.RunAction(true);
        }
    }

    public void UnInteract()
    {
        
    }
}
