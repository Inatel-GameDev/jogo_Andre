using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : inimigo
{
    
    void Start()
    {
        andando = "carangueijoCorrendo";
        preparando = "carangueijoPreparando";
        atacando = "carangueijoAtacando";

        sentidoOriginal = transform.eulerAngles.y;
        velocidade = -2;
        vida_maxima = 4;
        vida = vida_maxima;
        animator = GetComponent<Animator>();
        ataque = false;

    }
    

    
}
