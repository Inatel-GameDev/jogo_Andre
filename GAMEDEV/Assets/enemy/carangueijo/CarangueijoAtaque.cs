using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarangueijoAtaque : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject enemy;
    private player player;
    public Collider2D atq1;
    public Collider2D atq2;
    public bool atacando;

    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") && atacando)
        {
            player = cool.GetComponent<player>();
            player.levarDano(1, enemy.GetComponent<enemy>().sentido);
        
          
        }
    }

    void ataque()
    {
        atq1.enabled = true;
        atq2.enabled = true;
        atacando = true;

    }

    void EncerrarAtaque()
    {
        atq1.enabled = false;
        atq2.enabled = false;
        atacando = false;
        enemy.transform.eulerAngles = new Vector2(0, enemy.GetComponent<enemy>().sentidoOriginal);
        enemy.GetComponent<enemy>().ataque = false;
        enemy.GetComponent<enemy>().busca.enabled = true;
        enemy.GetComponent<enemy>().tempo = Time.time + enemy.GetComponent<enemy>().tempoEspera;
    }
    
}
