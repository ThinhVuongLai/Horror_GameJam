using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractItem
{
    [SerializeField] private float openAngle = 90.0f;

    [SerializeField] private float localYEulerAngle = 0f;
    [SerializeField] private float yEulerAngle = 0f;

    private bool inRunOpen = false;
    public bool canInteract { get; set; }

    private void Awake()
    {
        yEulerAngle = transform.eulerAngles.y;
        localYEulerAngle = transform.localEulerAngles.y;

        canInteract = true;
    }

    public void Highlight()
    {
        if (canInteract)
        {
            ScriptableObjectController.I.UpdateHighlightTextAction.RunAction("Press [E] to Open Door");
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

        yEulerAngle = transform.eulerAngles.y;
        localYEulerAngle = transform.localEulerAngles.y;
    }

    private void OpenDoor()
    {
        transform.Rotate(new Vector3(0, openAngle * Time.deltaTime, 0), Space.Self);

        if ((openAngle >= 0 && (transform.localEulerAngles.y >= openAngle))
            || (openAngle < 0 && transform.localEulerAngles.y <= (360 + openAngle)))
        {
            inRunOpen = false;
        }
    }
}
