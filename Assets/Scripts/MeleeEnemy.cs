using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBehaviour
{

    [SerializeField] int damage=1;
    Rigidbody2D rgdbd2d;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    public override void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination=target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction=(targetDestination.position-transform.position).normalized;
        rgdbd2d.velocity = direction*speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject==targetGameObject)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        if(targetCharacter==null)
        {
            targetCharacter=targetGameObject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
    }

    public override void TakeDamage(int damage)
    {
        hp-=damage;
        if(hp<1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }
    }
}
