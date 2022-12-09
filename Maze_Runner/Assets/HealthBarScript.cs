using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerHealth player;

    private void Start()
    {
        //find image
        HealthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
    }

    private void update()
    {
        CurrentHealth = player.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
