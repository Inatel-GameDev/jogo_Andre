using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morte : MonoBehaviour
{
    public player PlayerS;
    

         void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("Player"))
            {
                PlayerS = other.GetComponent<player>();
                PlayerS.levarDano(6, 1);
            }
        }
}
