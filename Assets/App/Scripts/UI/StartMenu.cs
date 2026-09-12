using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        //closeButton.onClick.AddListener(OnClickCloseButton);
    }

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        StartCoroutine(CRHide());
    }

    private void OnClickCloseButton()
    {
        gameObject.SetActive(false);
        GameManager.I.SetPauseGame(false);

        GameManager.I.SetCursorState(true);
    }

    IEnumerator CRHide()
    {
        yield return new WaitForSeconds(7f);
        OnClickCloseButton();
    }
}
