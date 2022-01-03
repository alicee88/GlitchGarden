using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherCollider = collision.gameObject;
        if(otherCollider.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherCollider);
        }
    }
}
