using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHoleController : MonoBehaviour, IInteractItem
{
    private bool haveMilk = false;

    public bool canInteract { get ; set ; }

    public void Highlight()
    {
        haveMilk = false;

        if (ScriptableObjectController.I.HaveMilkAction.Invoke())
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to use milk");
            haveMilk = true;
        }
        else
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Currently no milk");
        }
    }

    public void HoldInteract()
    {
        
    }

    public void Interact()
    {
        if(haveMilk)
        {
            ScriptableObjectController.I.UpdateHasMilkAction.RunAction(false);
        }
    }

    public void UnInteract()
    {
        
    }
}
