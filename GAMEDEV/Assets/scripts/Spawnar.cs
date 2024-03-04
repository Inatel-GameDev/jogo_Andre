using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnar : MonoBehaviour
{
    public GameObject player;
   public void spawnar(GameObject D)
   {
        Destroy(D); 
        Instantiate(player);
   } 
   
}
