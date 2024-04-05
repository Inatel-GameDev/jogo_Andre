using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moeda : coletaveis
{
    TextMeshProUGUI texto;
    GameObject textoObj;
    void Start()
    {
        textoObj = GameObject.FindWithTag("TextoMoeda");
        texto = textoObj.GetComponent<TextMeshProUGUI>();
        efeito = false;
    }

    void Update()
    {
        pegou();
    }
    void pegou()
    {
        if (efeito)
        {
            player.moedaAdd();
            texto.text = ""+player.quantidade;
            Destroy(coletavel);
        }
    }
}
