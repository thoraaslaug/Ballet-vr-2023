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
        // Only move the character if it is not currently dancing
        if (!isDancing)
        {
            // Calculate direction to the target position
            Vector3 direction = (targetPosition.position - transform.position).normalized;

            // Set animator parameters
           // animator.SetFloat("Speed", direction.magnitude);

            // Move the character towards the target position
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Dancer"))
        {
            
            // Set the "Dance" trigger to start the dance animation
            animator.SetBool("Dance", true);
            isDancing = true;
            
        }
        speed = 0f;
    }
}