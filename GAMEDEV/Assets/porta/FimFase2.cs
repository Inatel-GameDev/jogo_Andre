using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase2 : MonoBehaviour
{
    private Animator animator;

    private string currentAnimation;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerStay2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") )
        {
            changeAnimation("Abrir");
            if(Input.GetKeyDown("w"))
            {
                SceneManager.LoadScene("fase3", LoadSceneMode.Single);
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D coli)
    {
        if(coli.CompareTag("Player") )
        {
            changeAnimation("Fechar");
        }
    }

    public void changeAnimation(string newAnimation)
    {
        if(newAnimation == currentAnimation)
            return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}

