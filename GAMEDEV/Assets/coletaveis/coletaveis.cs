using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class coletaveis : MonoBehaviour
{
    public GameObject coletavel;
    public bool efeito;
    public player player;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<player>();
            efeito = true;
        }
    }
    
}
