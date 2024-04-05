using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubarao : inimigo
{
    // Start is called before the first frame update
    void Start()
    {
        andando = "tubaraoAndando";
        preparando = "tubaraoPreparando";
        atacando = "tubaraoAtacando";

        sentidoOriginal = transform.eulerAngles.y;
        velocidade = -1;
        vida_maxima = 6;
        vida = vida_maxima;
        animator = GetComponent<Animator>();
        ataque = false;
    }

}
