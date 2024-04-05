using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D cool)
    {
        if(cool.CompareTag("Player"))
        {
            SceneManager.LoadScene("fase2", LoadSceneMode.Single);
        }
    }
}
