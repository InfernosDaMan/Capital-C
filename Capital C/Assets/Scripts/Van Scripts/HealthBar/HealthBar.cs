using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public CharacterStats character;

    // Start is called before the first frame update
    void Start()
    {
        //checks if there is character attached to the current health bar
        if(character != null)
        {
            SetMaxHealth(character.maxHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if there is a character attached to the health bar change it's value to match that character's current health value
        if(character != null)
        {
            SetHealth(character.currentHealth);
        }
    }

    //used to set the intial value of the slider max to reflect the max hp of the character
    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //used to update the slider value to match the character health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
