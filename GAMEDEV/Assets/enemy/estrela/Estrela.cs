using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : inimigo
{
    // Start is called before the first frame update
    void Start()
    {
        andando = "EstrelaAndando";
        preparando = "EstrelaPreparando";
        atacando = "EstrelaAtacando";

        sentidoOriginal = transform.eulerAngles.y;
        velocidade = -2;
        vida_maxima = 2;
        vida = vida_maxima;
        animator = GetComponent<Animator>();
        ataque = false;
    }


}
