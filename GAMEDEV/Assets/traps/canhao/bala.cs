using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public GameObject tiro;
    public GameObject canhao;
    public player player;
    public Vector3 movimento;

    void Start() {
        
    }
    private void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("Player"))
        {
            player = cool.GetComponent<player>();
            if(tiro.transform.position.x < cool.GetComponent<Transform>().position.x)
            {
                player.levarDano(1, 1);
            }
            if(tiro.transform.position.x > cool.GetComponent<Transform>().position.x)
            {
                player.levarDano(1, -1);
            }
            
        }
        if(!cool.CompareTag("trap"))
        {
            Destroy(tiro);
        }
        
    }
    void Update()
    {
        transform.position += movimento * Time.deltaTime * 5;
    }
}
