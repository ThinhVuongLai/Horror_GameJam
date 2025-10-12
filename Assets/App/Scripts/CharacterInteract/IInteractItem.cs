using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractItem
{
    public void Highlight();
    public void Interact();
    public void HoldInteract();
    public void UnInteract();
}
