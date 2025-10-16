using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour, IInteractItem
{
    [SerializeField] private int foodIndex = 0;

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            string foodName = MergeFoodController.I.GetFoodName(foodIndex);
            if (string.IsNullOrEmpty(foodName))
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction($"Can't collect, Because not found FoodInfor");
            }
            else
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction($"Press [E] to Collect {foodName}");
            }
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
        ScriptableObjectController.I.UpdateInventeryFoodIndexAction.RunAction(foodIndex);
    }

    public void UnInteract()
    {

    }
}
