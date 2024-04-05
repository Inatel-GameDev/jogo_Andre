using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Spawnar : MonoBehaviour
{
    public GameObject player;
   public void spawnar()
   {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   } 
   
}
