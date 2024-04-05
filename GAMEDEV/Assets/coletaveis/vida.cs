using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : coletaveis
{
    
    // Start is called before the first frame update
    void Start()
    {
        efeito = false;
    }
    void Update()
    {
        if(efeito)
        {
            if(player.vida < 6)
                player.vida += 1;
            Destroy(coletavel);
        }
    }


}
