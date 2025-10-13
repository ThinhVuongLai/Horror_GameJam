using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractItem
{
    public bool canInteract { get; set; }

    public void Highlight();
    public void Interact();
    public void HoldInteract();
    public void UnInteract();
}
