using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeefController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Vector3 localPosition = Vector3.zero;
    private Vector3 localRotate=Vector3.zero;

    private void Awake()
    {
        localPosition = transform.localPosition;
        localRotate = transform.localEulerAngles;
    }

    public void ResetLeef()
    {
        transform.localPosition = localPosition;
        transform.localEulerAngles = localRotate;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }

    public void DropLeef()
    {
        _rigidbody.isKinematic = false;
    }
}
