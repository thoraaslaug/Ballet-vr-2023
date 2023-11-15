using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    public Transform targetPosition;
    public float speed = 3.0f;
    private bool isDancing = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
    }

    void Move()
    {
        Vector3 direction = (targetPosition.position - transform.position).normalized;

        // Calculate the new position
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

        // Set the new position directly
        transform.position = newPosition;

        // animator.SetFloat("Speed", direction.magnitude);
        animator.Play("Running");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Dancer"))
        {
            
            // Set the "Dance" trigger to start the dance animation
            animator.Play("Idle");
            isDancing = true;
            
        }
        speed = 0f;
    }
}