using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitingEnemy : EnemyBehaviour
{

    [SerializeField] float timeToAttack;
    float timer;
    [SerializeField] GameObject projectile;
    [SerializeField] [Range(0f,10f)] float followRange=6f;
    [SerializeField] [Range(0f,10f)] float projectileRange=9f; //Never make projectileRange<followRange !!
    private Collider2D myCollider;
    private Vector2 previousMove;


    Vector3 direction;
    bool inRange=false;
    bool isAlive=true;

    Animate animate;

    Rigidbody2D rgdbd2d;

    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        animate= GetComponent<Animate>();
        myCollider = GetComponent<Collider2D>();
    }



    public override void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        float distanceToTarget=Vector3.Distance(targetDestination.position,transform.position);
        if(isAlive)
        {
            animate.attack=-1;
            if(distanceToTarget>followRange)
             {
                  direction = (targetDestination.position - transform.position).normalized;
                  rgdbd2d.velocity = direction * speed;
                  if(previousMove!=rgdbd2d.velocity*-1)
                    previousMove=rgdbd2d.velocity;
                  else
                    rgdbd2d.velocity=new Vector2(0f,0f);
                  
             }
             else
             {
                 direction = (targetDestination.position - transform.position).normalized*-1;
                 rgdbd2d.velocity = direction * speed;
                 if(previousMove!=rgdbd2d.velocity*-1)
                    previousMove=rgdbd2d.velocity;
                 else
                    rgdbd2d.velocity=new Vector2(0f,0f);
             }
             animate.horizontal=rgdbd2d.velocity.x;

             if(distanceToTarget>projectileRange)
                 inRange = false;
             else
                 inRange = true;

             if(timer<timeToAttack)
             {
                 timer+=Time.deltaTime;
                 return;
             }

             timer=0;
             if(inRange)
             Attack();
        }
        else
            rgdbd2d.velocity=new Vector2(0f,0f);

    }

    public override void Attack()
    {
        animate.attack=1;
        StartCoroutine(AttackAnimation());
    }

    public override void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Die();
        }
    }

    private IEnumerator DeathAnimation() 
    {
        yield return new WaitForSeconds(1f); //Wait time, before destroying object
        Destroy(gameObject);
    }

    private IEnumerator AttackAnimation() 
    {
        yield return new WaitForSeconds(0.15f);
        Vector3 direction=(targetDestination.position-transform.position).normalized;
        GameObject newProjectile=Instantiate(projectile);
        newProjectile.transform.position=transform.position;
        newProjectile.GetComponent<EnemyProjectile>().SetDirection(direction.x,direction.y);
        float angle = Mathf.Atan2(direction.y, direction.x);
        newProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg+180);
    }

    private void Die()
    {
        isAlive = false;
        animate.death=1;
        if (myCollider != null) //While death animation is playing, turn of the collider
        {
            myCollider.enabled = false;
        }
        StartCoroutine(DeathAnimation()); //Start death animation
    }


}
