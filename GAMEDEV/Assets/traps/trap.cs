using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class trap : MonoBehaviour
{
    public Animator animator;
    public string currentAnimation;

    public GameObject armadilha;
    public GameObject bala;

    public Collider2D busca;

    public string atirando;
    public string parado;
    public float tempo;

    public int vida;
    public void levarDano(int dano)
    {
        vida -= dano;
        if(vida<=0)
        {
            Destroy(armadilha);
        }
    }

    private void OnTriggerStay2D(Collider2D cool)
    {
        if(cool.CompareTag("Player"))
        {
            trocarAnimacao(atirando);
        }
    }

    public void trocarAnimacao(string newAnimation)
    {
        if(newAnimation == currentAnimation)
            return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
    
    void iniciar()
    {
        busca.enabled = false;
    }
    void encerrar()
    {
        tempo = Time.timeSinceLevelLoad +2;
        trocarAnimacao(parado);
    }

    void delay()
    {
        if(tempo<Time.timeSinceLevelLoad)
        {
            busca.enabled = true;
        }
    }
    void fogo()
    {
        if(transform.eulerAngles.y == 0)
        {
            Instantiate(bala, new Vector3(armadilha.transform.position.x-1.5f, armadilha.transform.position.y, armadilha.transform.position.z), Quaternion.identity);
            bala.GetComponent<bala>().movimento = new Vector3(-1, 0f, 0f);
        }
        if(transform.eulerAngles.y == 180)
        {
            Instantiate(bala, new Vector3(armadilha.transform.position.x+1.5f, armadilha.transform.position.y, armadilha.transform.position.z), Quaternion.identity);
            bala.GetComponent<bala>().movimento = new Vector3(1, 0f, 0f);
        }

    }

}
