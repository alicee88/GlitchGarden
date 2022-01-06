using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var healthText = FindObjectOfType<HealthDisplay>();
        healthText.DealDamage();
    }
}
