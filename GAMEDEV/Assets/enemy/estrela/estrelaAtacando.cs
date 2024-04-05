using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrelaAtacando : MonoBehaviour
{
    public GameObject estrela ;
    public player player;
    public bool atacando;
    public float velocidade = 4;
    public bool veD;

    public float tempo;
    public int timer;

    void Start()
    {
        atacando = true;
        veD= false;
        tempo = 0;
        timer = 0;
    }
    void Update()
    {
        girando();

    }

    void OnTriggerEnter2D(Collider2D cool)
    { 
        if (cool.CompareTag("Player") && !atacando ) 
        { 
            player = cool.GetComponent<player>();
            if(!player.atacando){
                if(estrela.GetComponent<Transform>().position.x < cool.GetComponent<Transform>().position.x)
            {
                player.levarDano(4, 1);
            }
            else if(estrela.GetComponent<Transform>().position.x > cool.GetComponent<Transform>().position.x)
            {
                player.levarDano(4, -1);
            }
            
            }
            
        } 
        if (cool.gameObject.CompareTag("parede") && estrela.GetComponent<Estrela>().ataque) 
        { 
            
            transform.eulerAngles = new Vector2(0, transform.eulerAngles.y+180);
            velocidade = velocidade*-1;
            timer+=1;
            if(timer== 5)
            {
                tempo = Time.timeSinceLevelLoad+3;
                TimerAtq();
                estrela.GetComponent<Estrela>().trocarAnimacao("EstrelaParada");
            }
        } 
    } 

    public void girando()
    {
            Vector3 movimento = new Vector3(1f, 0f, 0f);
        if(!atacando)
        {
            estrela.GetComponent<Transform>().position += movimento * Time.deltaTime * velocidade;
        }
    }

    public void iniciar()
    {
        atacando = false;
        if(!veD)
        {
            if(estrela.GetComponent<Estrela>().sentido == 1)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if(estrela.GetComponent<Estrela>().sentido == -1)
            {
                
                transform.eulerAngles = new Vector2(0, 0);
                velocidade *= -1;
            }

            veD = true;
        }

    }

    public void TimerAtq()
    {
        if(timer == 5)
        {
            atacando = true;
            if(Time.timeSinceLevelLoad> tempo){
                atacando = false;
                timer = 0;
                estrela.GetComponent<Estrela>().trocarAnimacao("EstrelaAtacando");
            }
        }
        
        
    }
}
