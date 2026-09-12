using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDoorController : MonoBehaviour, IInteractItem
{
    [SerializeField] private GameObject milkObject;

    private bool canGetMilk = false;

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
        milkObject.gameObject.SetActive(false);
    }

    public void Highlight()
    {
        if (canInteract)
        {
            if (ScriptableObjectController.I.HaveDishAction.Invoke())
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to feed BeefSteak \nand receive milk");
                canGetMilk = true;
            }
            else
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Create BeefStreak to feed \nand receive milk");
                canGetMilk = false;
            }
        }
        else
        {
            canGetMilk = false;
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("");
        }
    }

    public void HoldInteract()
    {

    }

    public void Interact()
    {
        if (canGetMilk)
        {
            ScriptableObjectController.I.UpdateHasDishAction.RunAction(false);
            milkObject.SetActive(true);
        }
    }

    public void UnInteract()
    {

    }
}
