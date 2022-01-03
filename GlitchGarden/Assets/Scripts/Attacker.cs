using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0.0f;
    GameObject currentTarget;

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

}
