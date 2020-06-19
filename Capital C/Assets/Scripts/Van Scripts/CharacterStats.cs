using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stats damage;
    public Stats armor;

    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        
        //Debug.Log(healthBar);
    }

    void Update()
    {

    }

    //deals damage to player
    public void TakeDamage(int damage)
    {
        //clamps value to ensure player doesn't gain hp when armor is greater than damage
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        //deals calculated damage to object
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        //checks if object is now dead
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //displays in console that the object has died
        Debug.Log(transform.name + " died.");
    }
}
