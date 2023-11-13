using UnityEngine;

public class AnimControl : MonoBehaviour
{
    private Animator animator;
    public Transform targetPosition;
    public float walkSpeed = 3.0f;
    private bool isWalking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalking = true; // Assume the character starts walking
    }

    void Update()
    {
        if (isWalking)
        {
            // Calculate direction to the target position
            Vector3 direction = (targetPosition.position - transform.position).normalized;

            // Set animator parameters
            animator.SetFloat("Speed", direction.magnitude);

            // Move the character towards the target position
            transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (isWalking && collision.CompareTag("Dancer"))
        {
            // Set the "Dance" trigger to start the dance animation
            animator.SetBool("Dance", true);
            isWalking = false; // Stop walking when dancing
        }
    }

}