using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameObject playerCamera;
    
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
