using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTeacher : MonoBehaviour
{
    private Animator animator;
    public Transform targetPosition;
    public float walkSpeed = 3.0f;
    public float turnSpeed = 90.0f; // Rotation speed in degrees per second
    public float arrivalThreshold = 0.1f; // Distance threshold to consider the character has reached the target
    private bool isWalking = false;
    private bool hasPlayedFirstAnimation = false;
    private bool hasReachedTarget = false;
    private bool hasTurned = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayFirstAnimation();
    }

    void Update()
    {
        if (hasPlayedFirstAnimation && !hasReachedTarget)
        {
            MoveToTarget();
        }

        if (hasReachedTarget && !hasTurned)
        {
            TurnCharacter();
        }
    }

    void PlayFirstAnimation()
    {
        animator.Play("TeacherWalk");
        hasPlayedFirstAnimation = true;
    }

    void MoveToTarget()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("TeacherWalk"))
        {
            isWalking = true;
        }

        if (isWalking)
        {
            // Calculate direction to the target position
            Vector3 direction = (targetPosition.position - transform.position).normalized;

            // Set animator parameters
            animator.SetFloat("Speed", direction.magnitude);

            // Move the character towards the target position
            transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);

            // Check if the character has reached the target position
            if (Vector3.Distance(transform.position, targetPosition.position) <= arrivalThreshold)
            {
                hasReachedTarget = true;
                isWalking = false;
                animator.SetBool("Walking", true); // Start the walking animation
            }
        }
    }

    void TurnCharacter()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 90, 0); // 90-degree rotation around Y-axis

        // Rotate the character gradually
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Check if the character has turned
        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            hasTurned = true;
            animator.SetBool("Walking", false); // Stop the walking animation
        }
    }
}