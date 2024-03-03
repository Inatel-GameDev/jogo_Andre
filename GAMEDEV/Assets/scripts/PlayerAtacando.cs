using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtacando : MonoBehaviour
{
    // Start is called before the first frame update
    private enemy enemy;
    public player player;

    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("enemy") && player.atacando)
        {
          enemy = cool.GetComponent<enemy>();
          enemy.levarDano(1);
          player.atacando = false;
        }
    }
}
