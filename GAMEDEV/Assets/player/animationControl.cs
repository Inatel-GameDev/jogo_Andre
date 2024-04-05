using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour
{
    private Animator animator;

    private string currentAnimation;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void changeAnimation(string newAnimation)
    {
        if(newAnimation == currentAnimation)
            return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    public void JumpAnimation(string newAnimation ,float normalizedTime)
    {
        if(newAnimation == currentAnimation)
            return;
        animator.Play("playerPulando", 0, normalizedTime);
        currentAnimation = newAnimation;
    }
    

}
