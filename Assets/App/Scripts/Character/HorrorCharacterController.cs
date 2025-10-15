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

    [Header("Move Setting")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float accelerationRate = 10f;
    [SerializeField] private float decelerationRate = 10f;

    [Header("Look Setting")]
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private float cameraPitchMin = -70f;
    [SerializeField] private float cameraPitchMax = 70f;

    [Header("Grounded Settings")]
    public float groundedOffset = .85f;
    public float groundedRadius = 0.3f;
    public LayerMask groundLayers;

    [Header("Simulate Physic Seting")]
    public float gravity = -20f;

    private Vector3 characterVelocity = Vector3.zero;
    private float cameraPitch = 0;

    private bool isGrounded;

    private void Update()
    {
        HandleMove();
        HandleGravity();
        GroundedCheck();
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

    private void GroundedCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
        isGrounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
    }

    private void HandleGravity()
    {
        if (isGrounded && characterVelocity.y < 0)
        {
            characterVelocity.y = -2f;
        }
        characterVelocity.y += gravity * Time.deltaTime;
        characterController.Move(Vector3.up * characterVelocity.y * Time.deltaTime);
    }
}
