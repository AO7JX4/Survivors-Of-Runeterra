using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : EnemyBehaviour
{
    Vector3 direction;
    private Collider2D myCollider;
    Animate animate;
    Rigidbody2D rgdbd2d;
    private static float DODGE_DISTANCE=8f;

    [SerializeField] float timeToChangeDirection=4f;
    [SerializeField] GameObject marker;
    GameObject newMarker;
    Transform canvas;
    float timer;
    public override void Attack() {} //This enemy doesnt attack
    public override void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }


    private void Awake()
    {
        CanvasSingleton canvasSingleton = CanvasSingleton.instance;
        canvas= canvasSingleton.canvasTransform;
        rgdbd2d = GetComponent<Rigidbody2D>();
        animate= GetComponent<Animate>();
        myCollider = GetComponent<Collider2D>();
        direction=Vector3.one;
        newMarker=Instantiate(marker,canvas);
        newMarker.GetComponent<ScuttleMarker>().SetTarget(gameObject);
    }

    private void FixedUpdate()
    {
        List<GameObject> closeProjectiles= FindProjectilesClose();
        
            
        if(closeProjectiles.Count>0)
        {
            Dodge();
        }
        else
        {
             WanderAround();
        }
        if (rgdbd2d.velocity.x > 0)
        {
            // Moving right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (rgdbd2d.velocity.x < 0)
        {
            // Moving left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

           
    }

    public override void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
           
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }
    }

    private List<GameObject> FindProjectilesClose()
    {
    
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("PlayerProjectile");
        List<GameObject> closeProjectiles=new List<GameObject>();
        for(int i=0; i<projectiles.Length; i++)
        {
             float distance = Vector3.Distance(transform.position, projectiles[i].transform.position);
             if(distance <DODGE_DISTANCE)
                closeProjectiles.Add(projectiles[i]);
        }
        return closeProjectiles;
    }

   private GameObject FindClosestProjectile(List<GameObject> closeProjectiles)
    {
        GameObject closestProjectile = null;
        float closestDistance = Mathf.Infinity;

        Transform playerTransform = transform; 

        foreach (GameObject projectile in closeProjectiles)
        {
            if (projectile != null)
            {
                float distance = Vector3.Distance(projectile.transform.position, playerTransform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestProjectile = projectile;
                }
            }
        }

        return closestProjectile;
    }
            
    
    private void Dodge()
    {
        GameObject closestProjectileObject = FindClosestProjectile(FindProjectilesClose());
        Spell_Yasuo_T closestProjectile = closestProjectileObject.GetComponent<Spell_Yasuo_T>();
        Vector3 projectileDir = closestProjectile.getDirection();
        float dodgeSpeed = speed * 2;
    
        Vector3 toProjectile = closestProjectileObject.transform.position - transform.position;
    
        float crossZ = Vector3.Cross(toProjectile, projectileDir).z;
    
        if (crossZ > 0)
        {
            Vector3 dodgeDirection = new Vector3(-projectileDir.y, projectileDir.x, 0f);
            direction = dodgeDirection.normalized;
        }
        else
        {
            Vector3 dodgeDirection = new Vector3(projectileDir.y, -projectileDir.x, 0f);
            direction = dodgeDirection.normalized;
        }
    
        rgdbd2d.velocity = direction * dodgeSpeed;
    }

    private void WanderAround()
    {
        
        if(timer<timeToChangeDirection)
            timer+=Time.deltaTime;
        else
        {
             float angle = UnityEngine.Random.Range(-135f, 135f);
             direction = Quaternion.Euler(0f, 0f, angle) * direction;
            timer=0;
        }
        rgdbd2d.velocity = direction * speed;
    }
}
