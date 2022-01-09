using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;

    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
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
