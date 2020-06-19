using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {

        //checks if there is an existing equipment manager
        if (EquipmentManager.instance != null)
        {
            EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if you press the follow key the player will take damage
        if (Input.GetKeyDown(KeyCode.T))
        {
            //the take damage method can be found in the character stats code
            TakeDamage(10);
        }
    }

    //method called which changes the stats off the player whenever items are switched out
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        //calls die
        base.Die();
        //singleton reference to the player
        PlayerManager.instance.KillPlayer();
    }
}
