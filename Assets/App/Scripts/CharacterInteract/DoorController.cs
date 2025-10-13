using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractItem
{
    [SerializeField] private float openAngle = 90.0f;

    private bool inRunOpen = false;
    public bool canInteract { get; set; }

    private void Awake()
    {
        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            ScriptableObjectController.instance.UpdateHighlightTextAction.RunAction("Press [E] to Open Door");
        }
        else
        {
            ScriptableObjectController.instance.UpdateHighlightTextAction.RunAction("");
        }
    }

    public void HoldInteract()
    {

    }

    public void Interact()
    {
        canInteract = false;
        inRunOpen = true;
    }

    public void UnInteract()
    {

    }

    private void Update()
    {
        if (!inRunOpen)
            return;

        OpenDoor();
    }

    private void OpenDoor()
    {
        transform.Rotate(new Vector3(0, openAngle * Time.deltaTime, 0), Space.Self);

        if (transform.localEulerAngles.y >= openAngle)
        {
            inRunOpen = false;
        }
    }
}
