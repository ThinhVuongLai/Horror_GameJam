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
        
    }

    public void HoldInteract()
    {
        
    }

    public void Interact()
    {
        
    }

    public void UnInteract()
    {
        
    }
}
