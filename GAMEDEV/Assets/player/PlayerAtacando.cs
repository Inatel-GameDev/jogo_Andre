using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtacando : MonoBehaviour
{
    // Start is called before the first frame update
    private inimigo enemy;
    private trap armadilha;
    public player player;

    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("enemy") && player.atacando)
        {
          enemy = cool.GetComponent<inimigo>();
          enemy.levarDano(1);
          player.atacando = false;
        }
        if(cool.CompareTag("trap") && player.atacando)
        {
          armadilha = cool.GetComponent<trap>();
          armadilha.levarDano(1);
          player.atacando = false;
        }
    }
}
