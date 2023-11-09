using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : MonoBehaviour
{
    
    public float delayTime = 10f; // Set the delay time to 10 seconds
    public AnimationClip animationToPlay; // Reference to the animation clip

    public Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Start the animation delay
        StartCoroutine(PlayAnimationWithDelay());
    }

    IEnumerator PlayAnimationWithDelay()
    {
        // Wait for the specified delay time (10 seconds in this case)
        yield return new WaitForSeconds(delayTime);

        // Play the animation after the delay
        if (animationToPlay != null)
        {
            animator.Play(animationToPlay.name);
        }
        // Alternatively, if you want to play the default animation without specifying a clip:
        // animator.Play("YourAnimationName");
    }
}

