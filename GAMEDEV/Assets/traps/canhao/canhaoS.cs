using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canhaoS : trap
{
    // Start is called before the first frame update
    void Start()
    {
        tempo = 0;
        vida = 3;
        animator = GetComponent<Animator>();

        atirando = "canhaoAtirando";
        parado = "canhaoParado";
    }

}
