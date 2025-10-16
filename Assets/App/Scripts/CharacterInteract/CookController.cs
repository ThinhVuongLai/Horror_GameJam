using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookController : MonoBehaviour, IInteractItem
{
    [SerializeField] private List<GameObject> showFoodObject = new List<GameObject>();
    [SerializeField] private GameObject dishObject = null;

    [Header("Setting")]
    [SerializeField] private float cookSecond = 10;

    private bool canCook = false;

    private WaitForSeconds cookDelay = null;

    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
        cookDelay = new WaitForSeconds(cookSecond);
        dishObject.SetActive(false);
    }

    public void Highlight()
    {
        if (canInteract)
        {
            List<int> foodIndexs = ScriptableObjectController.I.GetInventeryFoodIndexAction.RunAction();

            bool hasCook = MergeFoodController.I.CanCook(foodIndexs);
            this.canCook = hasCook;

            if (hasCook)
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to Cook");
            }
            else
            {
                ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Unable to cook due to lack of food");
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
        if(canCook)
        {
            canCook = false;
            canInteract = false;
            
            ScriptableObjectController.I.SetLockCharacterAction.RunAction(true);
            for (int i = 0, length = showFoodObject.Count; i < length; i++)
            {
                showFoodObject[i].SetActive(true);
            }

            ScriptableObjectController.I.CookAction.RunAction();

            StartCoroutine(CRCook());
        }
    }

    public void UnInteract()
    {
        
    }

    private IEnumerator CRCook()
    {
        yield return cookDelay;

        ScriptableObjectController.I.SetLockCharacterAction.RunAction(false);

        for (int i = 0, length = showFoodObject.Count; i < length; i++)
        {
            showFoodObject[i].SetActive(false);
        }

        dishObject.SetActive(true);
    }
}
