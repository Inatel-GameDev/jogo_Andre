using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject playerGO;
    public player playerS;
    private string currentAnimation;
    private Animator animator;

    public int vidaMaxima;
    public int vida;

    public Collider2D busca;
    public Collider2D atq1;
    public Collider2D atq2;

    private bool atacando;
    private float tempo;
    float tempoEspera = 2;

    private bool mover;
    public float velocidade;
   

    


    void Start()
    {
        tempo = tempoEspera;
        mover = true;
        atacando = false;
        animator = GetComponent<Animator>();
        vida = vidaMaxima;
        playerS = playerGO.GetComponent<player>();
        atq1.enabled = false;
        atq1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    void move()
    {
        
            Vector3 movimento = new Vector3(1f, 0f, 0f);
        if(mover)
        {
            transform.position += movimento * Time.deltaTime * velocidade;
            trocarAnimacao("carangueijoCorrendo");
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("chao")){
            velocidade = velocidade*-1;
            
        }
    }

    public void trocarAnimacao(string newAnimation)
    {
        if(newAnimation == currentAnimation)
            return;

        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    public void levarDano(int dano)
    {
        vida = vida - dano;
    }

    private void OnTriggerStay2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") && !atacando){
            StartCoroutine(Preparar());
        }
        if(cool.CompareTag("Player") && atacando)
        {
            StartCoroutine(AtacarAc());
        }
        if(!cool.CompareTag("Player") && atacando)
        {
            StartCoroutine(Atacar());
        }
    }

    private IEnumerator Preparar()
    {
        trocarAnimacao("carangueijoPreparando");
        mover = false;
        busca.enabled = false;
        yield return new WaitForSeconds(0.5f);
        atacando = true;
        atq1.enabled = true;
        atq2.enabled = true;
        
    }

    private IEnumerator AtacarAc()
    {
        trocarAnimacao("carangueijoAtacando");
        if(Time.time > tempo){
            playerS.levarDano(1);
            tempo = Time.time + tempoEspera;
        }
        yield return new WaitForSeconds(1f);
        mover = true;
        atacando = false;
        busca.enabled = true;
        atq1.enabled = false;
        atq2.enabled = false;
    }

    private IEnumerator Atacar()
    {
        trocarAnimacao("carangueijoAtacando");
        yield return new WaitForSeconds(1f);
        mover = true;
        atacando = false;
        busca.enabled = true;
        atq1.enabled = false;
        atq2.enabled = false;
    }
    
    
}