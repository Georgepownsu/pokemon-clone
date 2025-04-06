using UnityEngine;
using System.Collections;  // Ensure this is included for IEnumerator

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;  // Fixed typo: renamed to match standard naming conventions
    public LayerMask solidObjectsLayer;  // For other solid objects
    public LayerMask rocksLayer;  // For rocks layer

    private bool isMoving;
    private Vector2 input;

    private Animator animator;  // Add a reference to Animator

    private void Awake()
    {
        animator = GetComponent<Animator>();  // Cache reference to Animator
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // Remove diagonal movement (only allow one axis of movement at a time)
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Check if the target position overlaps with any solid object layer
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        // Check if the target position overlaps with any rock object layer
        if (Physics2D.OverlapCircle(transform.position, 0.2f, rocksLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)  // Random encounter check
            {
                Debug.Log("Fight!");
            }
        }
    }
}
