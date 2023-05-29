using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int mana;
    public int availableMana;
    public int maxMana = 10;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    void Start()
    {
        health = maxHealth;
        mana = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health.ToString();
        manaText.text = "Mana: " + availableMana.ToString();
    }
    public void OnNewTurn()
    {
        //draw
        mana++;
        availableMana = mana;
        if(mana >= maxMana)
        {
            mana = maxMana;
        }
    }
    public void DamageHealth(int damage)
    {
        health -= damage;
    }
}
