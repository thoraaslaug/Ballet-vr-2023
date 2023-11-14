using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Dancing_Walk : MonoBehaviour
{
    public Transform targetDestination; // The spot where you want the character to move
    public Animator animator; // Reference to the Animator component
    public AnimationClip danceAnimation; // Reference to the dance animation clip
    public AnimationClip walkToSpotAnimation; // Reference to the walk-to-spot animation clip
    public float danceDuration = 10f; // Duration of the dance animation in seconds
    public float movementSpeed = 5f; // Speed at which the character moves

    private bool isDancing = false;
    private bool isMoving = false;

    void Start()
    {
        StartCoroutine(PerformDanceAndMove());
    }

    IEnumerator PerformDanceAndMove()
    {
        // Play the dance animation
        if (animator != null && danceAnimation != null)
        {
            animator.Play(danceAnimation.name);
            isDancing = true;
        }

        yield return new WaitForSeconds(danceDuration);

        // Stop the dance animation
        if (animator != null && danceAnimation != null)
        {
            animator.SetBool("IsDancing", false);
            isDancing = false;
        }

        // Play the walk-to-spot animation
        if (animator != null && walkToSpotAnimation != null)
        {
            animator.Play(walkToSpotAnimation.name);
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToDestination();
        }
    }
    
    public void PivotTo(Vector3 position)
    {
        Vector3 offset = transform.position - position;
        foreach (Transform child in transform)
            child.transform.position += offset;
        transform.position = position;
    }

    void MoveToDestination()
    {
        if (targetDestination != null)
        {
            // Calculate direction towards the target
            Vector3 direction = (targetDestination.position - transform.position).normalized;

            // Move towards the target at a fixed speed
            transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);

            // Rotate the character to face the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);

            // Check for collisions with obstacles
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, movementSpeed * Time.deltaTime))
            {
                if (hit.collider.gameObject != targetDestination.gameObject) // Ignore collision with the destination point
                {
                    isMoving = false;
                    Debug.Log("Obstacle detected! Stopping movement.");
                    // Trigger idle animation or any other action upon reaching an obstacle
                    if (animator != null)
                    {
                        animator.SetBool("IsWalking", false);
                    }
                    return;
                }
            }

            // Check if the character has reached the destination
            float distance = Vector3.Distance(transform.position, targetDestination.position);
            if (distance < 0.1f)
            {
                isMoving = false;
                // Trigger idle animation or any other action upon reaching the destination
                if (animator != null)
                {
                    animator.SetBool("IsWalking", false);
                }
            }
            else
            {
                isMoving = true;
                // Trigger walk animation
                if (animator != null)
                {
                    animator.SetBool("IsWalking", true);
                }
            }
        }
    }
}





