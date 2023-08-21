using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    //public TextMeshProUGUI statsText;
    public CharacterStats characterStats;

    public float health;
    private int healthCalculator;

    private int rng;

    public Image healthBar;
    public float maxHealth;

    public TMP_Text healthText;
    private string healthString;

    public TMP_Text maxHealthText;

    void Start()
    {
        CharacterStats.Stats selectedStats = CharacterDataHolder.SelectedCharacterStats;
        healthCalculator = selectedStats.vitality;

        HealthRoll();
        maxHealth = health;

        healthString = health.ToString();
        healthText.text = healthString;
        maxHealthText.text = healthString;

    }

    private void Update()
    {
        //TESTING FUNCTIONS FOR HEALTH
        /*if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Heal(1);
        }*/
    }


    private void HealthRoll()
    {
        if (healthCalculator == 1)
        {
            health = 3;
        }
        else if (healthCalculator == 2)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 4;
            }
            else
            {
                health = 5;
            }
        }
        else if (healthCalculator == 3)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 5;
            }
            else
            {
                health = 6;
            }
        }
        else if (healthCalculator == 4)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 6;
            }
            else
            {
                health = 8;
            }
        }
        else if (healthCalculator == 5)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 7;
            }
            else
            {
                health = 8;
            }
        }
        else if (healthCalculator == 6)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 8;
            }
            else
            {
                health = 9;
            }
        }
        else if (healthCalculator == 7)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 9;
            }
            else
            {
                health = 10;
            }
        }
        else if (healthCalculator == 8)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 9;
            }
            else
            {
                health = 11;
            }
        }
        else if (healthCalculator == 9)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 10;
            }
            else
            {
                health = 12;
            }
        }
        else if (healthCalculator == 10)
        {
            rng = Random.Range(0, 100);
            if (rng < 50)
            {
                health = 15;
            }
            else
            {
                health = 20;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.fillAmount = health / maxHealth;

        healthString = health.ToString();
        healthText.text = healthString;

    }

    public void Heal(int healingAmount)
    {
        health += healingAmount;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.fillAmount = health / maxHealth;

        healthString = health.ToString();
        healthText.text = healthString;
    }

}
