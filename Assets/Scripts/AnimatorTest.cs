using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public string activateAnimation = "damage";

    public Animator animator;

    private void OnValidate()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) )
        {
            animator.SetBool(activateAnimation,!animator.GetBool(activateAnimation));
        }
    }

}
