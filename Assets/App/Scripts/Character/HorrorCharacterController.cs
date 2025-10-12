using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorCharacterController : MonoBehaviour
{
    [SerializeField] private Transform characterTransform = null;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private CharacterInputController inputController;
    [SerializeField] private  CinemachineVirtualCamera cinemachineVirtualCamera;

    [Header("Move Option")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float accelerationRate = 10f;
    [SerializeField] private float decelerationRate = 10f;

    [Header("Look Option")]
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private float cameraPitchMin = -70f;
    [SerializeField] private float cameraPitchMax = 70f;

    private Vector3 characterVelocity = Vector3.zero;
    private float cameraPitch = 0;

    private void Update()
    {
        HandleMove();
    }

    private void LateUpdate()
    {
        HandleLook();
    }

    private void HandleMove()
    {
        Vector2 inputMoveDirect = inputController.Move;
        Vector3 moveDirect = (characterTransform.right * inputMoveDirect.x) + (characterTransform.forward * inputMoveDirect.y);

        if (moveDirect != Vector3.zero)
        {
            characterVelocity.x = Mathf.Lerp(characterVelocity.x, moveSpeed * moveDirect.x, Time.deltaTime * accelerationRate);
            characterVelocity.z = Mathf.Lerp(characterVelocity.z, moveSpeed * moveDirect.z, Time.deltaTime * accelerationRate);
        }
        else
        {
            characterVelocity.x = Mathf.Lerp(characterVelocity.x, 0, Time.deltaTime * decelerationRate);
            characterVelocity.z = Mathf.Lerp(characterVelocity.z, 0, Time.deltaTime * decelerationRate);
        }

        characterController.Move(new Vector3(characterVelocity.x, 0, characterVelocity.z) * Time.deltaTime);
    }

    private void HandleLook()
    {
        Vector2 inputLockDirect = inputController.Look;
        cameraPitch -= inputLockDirect.y * rotationSpeed;
        cameraPitch = Mathf.Clamp(cameraPitch, cameraPitchMin, cameraPitchMax);

        cinemachineVirtualCamera.transform.localEulerAngles = new Vector3(cameraPitch, 0, 0);
        characterTransform.Rotate(Vector3.up * inputLockDirect.x * rotationSpeed);
    }
}
