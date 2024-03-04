using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarangueijoAtaque : MonoBehaviour
{
    // Start is called before the first frame update
     public enemy enemy;
    private player player;

    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") && enemy.atacando)
        {
          player = cool.GetComponent<player>();
          if(enemy.transform.position.x> player.transform.position.x)
          {
                player.levarDano(1, -1);
          }
          if(enemy.transform.position.x < player.transform.position.x)
          {
                player.levarDano(1, 1);
          }
            enemy.atq1.enabled = false;
            enemy.atq2.enabled = false;
            enemy.atacando = false;
        }
    }
}
