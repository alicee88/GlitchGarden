using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0.0f;
    GameObject currentTarget;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if(!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
        
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if(!currentTarget) { return; }

        Health health = currentTarget.GetComponent<Health>();

        if (health)
        {
            currentTarget.GetComponent<Health>().ProcessHit(damage);
        }
    }

}
