using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherCollider = collision.gameObject;

        if(otherCollider.name == "Tombstone")
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else if(otherCollider.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherCollider);
        }
        
    }
}
