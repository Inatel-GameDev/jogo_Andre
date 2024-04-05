using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubaraoAtaque : MonoBehaviour
{
    public GameObject tubarao;
    private player player;

    public bool atacando;

    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("Player") && atacando)
        {
            player = cool.GetComponent<player>();
            player.levarDano(2, tubarao.GetComponent<tubarao>().sentido);
        
          
        }
    }

    void ataque()
    {

        atacando = true;

    }

    void EncerrarAtaque()
    {
        atacando = false;
        tubarao.transform.eulerAngles = new Vector2(0, tubarao.GetComponent<tubarao>().sentidoOriginal);
        tubarao.GetComponent<tubarao>().ataque = false;
        tubarao.GetComponent<tubarao>().busca.enabled = true;
        tubarao.GetComponent<tubarao>().tempo = Time.time + tubarao.GetComponent<tubarao>().tempoEspera;
    }


}
