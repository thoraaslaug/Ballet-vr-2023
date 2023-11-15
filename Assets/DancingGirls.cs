using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DancingGirls : MonoBehaviour
{

    private Animator animator;
    public Transform targetPosition;
    public float walkSpeed = 3.0f;
   // public float turnSpeed = 90.0f; // Rotation speed in degrees per second
    public float arrivalThreshold = 0.1f; // Distance threshold to consider the character has reached the target
    private bool isWalking = false;
    private bool hasPlayedFirstAnimation = false;
    private bool hasReachedTarget = false;
    private bool hasTurned = false;
    public GameObject frida;
    public float rotationAngle = 180f;

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
    }

    void PlayFirstAnimation()
    {
        animator.Play("Ballet");
        hasPlayedFirstAnimation = true;
    }
    
  void MoveToTarget()
  {
  
       
      if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Ballet") && !hasTurned)
      {
          isWalking = true;
          TurnCharacter();
      }

      if (isWalking)
      {
          animator.Play("Running");
   
          Vector3 direction = (targetPosition.position - transform.position).normalized;

          // Calculate the new position
          Vector3 newPosition = transform.position + direction * walkSpeed * Time.deltaTime;

          // Set the new position directly
          transform.position = newPosition;

         // animator.SetFloat("Speed", direction.magnitude);
          

          // Check if the character has reached the target position
          if (Vector3.Distance(transform.position, targetPosition.position) <= arrivalThreshold)
          {
              hasReachedTarget = true;
              isWalking = false;
              animator.Play("Giggle");
             animator.SetBool("Walking", true);
           
          }
      }
  }

    void TurnCharacter()
    {
        transform.Rotate(0, rotationAngle, 0);
        hasTurned = true;
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Frida"))
        {
            
            Destroy(frida);
            Debug.Log("destroy mankind");
        }
      
    }
}