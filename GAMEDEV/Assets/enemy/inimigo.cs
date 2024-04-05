using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inimigo : MonoBehaviour
{
    public Animator animator;
    public string currentAnimation;
    public string andando;
    public string preparando;
    public string atacando;

    public Transform player;

    public GameObject monstro;
    public int vida_maxima;
    public int vida;

    public Collider2D busca;
    public bool ataque;
    public float tempo = 0;
    public float tempoEspera = 2;
    public float sentido;

    public float velocidade;
    public float sentidoOriginal;


    void Update()
    {
        move();
    }

    public void move()
    {
            Vector3 movimento = new Vector3(1f, 0f, 0f);
        if(!ataque)
        {
            transform.position += movimento * Time.deltaTime * velocidade;
            trocarAnimacao(andando);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("chao") && !ataque){
            velocidade = velocidade*-1;
            transform.eulerAngles = new Vector2(0, transform.eulerAngles.y+180);
            sentidoOriginal = transform.eulerAngles.y;
        }
    }

    private void OnTriggerStay2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") && !ataque && (Time.time > tempo)){
            StartCoroutine(Preparar());
            player = cool.GetComponent<Transform>();
        }
    }
    

    public void levarDano(int dano)
    {
        vida = vida - dano;
        if(vida <= 0)
        {
            Destroy(monstro);
        }
    }



    public void trocarAnimacao(string newAnimation)
    {
        if(newAnimation == currentAnimation)
            return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    public IEnumerator Preparar()
    {
        ataque = true;
        trocarAnimacao(preparando);
        busca.enabled = false;
        yield return new WaitForSeconds(0.5f);
        
        if(monstro.GetComponent<Transform>().position.x < player.position.x)
        {
            transform.eulerAngles = new Vector2(0, 180);
            sentido = 1;

        }
        else if(monstro.GetComponent<Transform>().position.x > player.position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
            sentido = -1;
        }
        trocarAnimacao(atacando);
        
        
    }
}
