using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 2000f;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("MazeGenerator");
        //find image
        HealthBar = GetComponent<Image>();
        GetComponent<PlayerHealth>();
    }

    private void update()
    {
        CurrentHealth = player.GetComponent<PlayerHealth>().GetHealth();
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
