using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] GameObject deathVFXPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SpawnDeathVFX();
        Destroy(gameObject);
    }

    private void SpawnDeathVFX()
    {
        if(!deathVFXPrefab) { return;  }
        GameObject deathVFX = Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        Destroy(deathVFX, 1f);
    }
}
