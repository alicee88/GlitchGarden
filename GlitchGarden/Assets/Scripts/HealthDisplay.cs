using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int playerHealthEasy = 5;
    [SerializeField] int playerHealthNormal = 3;
    [SerializeField] int playerHealthHard = 1;

    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    int playerHealth;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        switch((Difficulty)(PlayerPrefsController.GetDifficulty()))
        {
            case (Difficulty.EASY):
            {
                playerHealth = playerHealthEasy; 
                break;
            }
            case (Difficulty.NORMAL):
            {
                playerHealth = playerHealthNormal;
                break;
            }
            case (Difficulty.HARD):
            {
                playerHealth = playerHealthHard;
                break;
            }
        }
        healthText = GetComponent<Text>();
        healthText.text = playerHealth.ToString();
    }

    public void DealDamage()
    {
        playerHealth--;

        if(playerHealth <= 0)
        {
            playerHealth = 0;
            FindObjectOfType<LevelController>().HandleLose();
        }

        healthText.text = playerHealth.ToString();


    }
}
