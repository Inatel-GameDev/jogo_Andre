using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
    public GameObject P;
    private animationControl animationController;
    public GameObject Spawn;
    public Spawnar SpawnS;


    public float velocidade;
    public float VY;
    private Rigidbody2D rigid;
    private SpriteRenderer flip;

    public Collider2D atq;
    public bool atacando;

    public int vidaMaxima;
    public int vida;
    public bool hit;

    bool pulando = false;
    int doispulo = 0;

    

    Vector3 parado = new Vector3(0f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {
        SpawnS = Spawn.GetComponent<Spawnar>();
        hit = false;
        vida = vidaMaxima;
        atq.enabled = true;
        atacando = false;
        rigid = GetComponent<Rigidbody2D>();
        animationController = GetComponent<animationControl>();
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ataque();
        move();
        jump();
        
        
    }

    void move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        if(!atacando && !hit){
            transform.position += movimento * Time.deltaTime * velocidade;
        }
        
        if(movimento != parado && !pulando && !atacando && !hit)
        {
            animationController.changeAnimation("playerCorrendo");

        }
        else if(movimento == parado && !pulando && !atacando && !hit) 
        {
            
            animationController.changeAnimation("playerParado");
        }  
             
        if(Input.GetKey("left") || Input.GetKey("d"))
        {
            flip.flipX = false;
            if(atq.offset.x < 0)
                atq.offset = atq.offset* new Vector2(-1, 1);
        }
        if(Input.GetKey("right") || Input.GetKey("a"))
        {
            flip.flipX = true;
            if(atq.offset.x > 0)
                atq.offset = atq.offset* new Vector2(-1, 1);
        
        }
        

    }

    void jump()
    {
        
        if(Input.GetKeyDown("space") && (!pulando || doispulo != 2) && !atacando)
        {
            
            rigid.AddForce(new Vector2(0f, VY), ForceMode2D.Impulse);
            doispulo += 1;
            
        }

        if(rigid.velocity.y > 0 && !hit )
        {
            animationController.JumpAnimation("PlayerPulando" ,0.4f);
        }
        
        if(rigid.velocity.y < 0  && !hit)
        {
            animationController.changeAnimation("PlayerCaindo");
        }
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            pulando = false;
            doispulo = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            pulando = true;
        }
    }

    void ataque()
    {
        if(Input.GetKeyDown("e") && !atacando && !pulando && !hit)
        {
            StartCoroutine(FazerAtaque());
        }
    }

    private IEnumerator FazerAtaque()
    {
        animationController.changeAnimation("playerAtacando");
        atacando = true;    
        yield return new WaitForSeconds(0.5f);
        atacando = false;
    }

    public void levarDano(int dano, float sentido)
    {
        if(vida > 0)
        {
            vida -= dano;
            hit = true;
            rigid.AddForce(new Vector2(2f*sentido, 2f), ForceMode2D.Impulse);
            StartCoroutine(anim());
            
        }
        if(vida<=0)
        {
            SpawnS.spawnar(P);
        }            
    }

    IEnumerator anim()
    {
        animationController.changeAnimation("playerDano");
        yield return new WaitForSeconds(0.5f);
        hit = false;
    }


}
