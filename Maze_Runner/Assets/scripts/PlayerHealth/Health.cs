using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerHealth player;
    public Image image;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        //Retriving data of the UI slider
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Storing the health value within the slider every update
        float maxHealth = 100f;
        float fill = player.health / maxHealth;
        slider.value = fill;
    }
}
