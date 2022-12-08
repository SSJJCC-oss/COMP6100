using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject playerCamera;
    
    void Start()
    {
        //playerCamera = GameObject.Find("Player Camera");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // Destroy(gameObject);
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
