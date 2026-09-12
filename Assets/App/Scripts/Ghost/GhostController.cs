using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    [Header("Bounds (define rectangle using A and B)")]
    [SerializeField] private Vector2 pointA = new Vector2(-5f, -3f);
    [SerializeField] private Vector2 pointB = new Vector2(5f, 3f);

    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float reachThreshold = 0.05f;
    [SerializeField] private bool autoStart = true;

    private Vector2 currentTarget;
    private bool isMoving;

    private void Start()
    {
        currentTarget = PickRandomTarget();
        if (autoStart) StartMoving();
    }

    private void Update()
    {
        if (!isMoving) return;

        Vector3 position3 = transform.position;
        Vector2 position2 = new Vector2(position3.x, position3.y);

        // Move towards current target
        Vector2 newPos = Vector2.MoveTowards(position2, currentTarget, speed * Time.deltaTime);
        transform.position = new Vector3(newPos.x, position3.y, newPos.y);

        // Check if reached
        if (Vector2.Distance(newPos, currentTarget) <= Mathf.Max(reachThreshold, 0.0001f))
        {
            currentTarget = PickRandomTarget();
        }
    }

    // Returns and stores a random point inside the rectangle defined by pointA and pointB
    private Vector2 PickRandomTarget()
    {
        float minX = Mathf.Min(pointA.x, pointB.x);
        float maxX = Mathf.Max(pointA.x, pointB.x);
        float minY = Mathf.Min(pointA.y, pointB.y);
        float maxY = Mathf.Max(pointA.y, pointB.y);

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        currentTarget = new Vector2(x, y);
        return currentTarget;
    }

    // Public controls
    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            // Ensure we have a valid target
            if (currentTarget == Vector2.zero && !IsInsideBounds(transform.position))
            {
                currentTarget = PickRandomTarget();
            }
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public void MoveToRandomNow()
    {
        currentTarget = PickRandomTarget();
        isMoving = true;
    }

    public void SetBounds(Vector2 a, Vector2 b, bool pickNewTarget = true)
    {
        pointA = a;
        pointB = b;
        if (pickNewTarget) currentTarget = PickRandomTarget();
    }

    // Helper: test if a world point is inside bounds rect (ignores z)
    private bool IsInsideBounds(Vector3 worldPos)
    {
        float minX = Mathf.Min(pointA.x, pointB.x);
        float maxX = Mathf.Max(pointA.x, pointB.x);
        float minY = Mathf.Min(pointA.y, pointB.y);
        float maxY = Mathf.Max(pointA.y, pointB.y);
        return worldPos.x >= minX && worldPos.x <= maxX && worldPos.y >= minY && worldPos.y <= maxY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.I.SetPauseGame(true);
            ScriptableObjectController.I.ShowLoseAction.RunAction();
        }
    }

#if UNITY_EDITOR
    // Editor visualization
    private void OnDrawGizmosSelected()
    {
        // Draw rectangle bounds
        Vector3 a = new Vector3(pointA.x, pointA.y, transform.position.z);
        Vector3 b = new Vector3(pointB.x, pointA.y, transform.position.z);
        Vector3 c = new Vector3(pointB.x, pointB.y, transform.position.z);
        Vector3 d = new Vector3(pointA.x, pointB.y, transform.position.z);

        Gizmos.color = new Color(0f, 1f, 1f, 0.25f);
        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(b, c);
        Gizmos.DrawLine(c, d);
        Gizmos.DrawLine(d, a);

        // Draw the current target
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(currentTarget.x, currentTarget.y, transform.position.z), 0.08f);

        // Line from object to target
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(currentTarget.x, currentTarget.y, transform.position.z));
    }
#endif
}
