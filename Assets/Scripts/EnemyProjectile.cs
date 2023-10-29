using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int damage=5;


     public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);
    }

    bool hitDetected=false;
    void Update()
    {
        transform.position+=direction*speed*Time.deltaTime;
        
        Collider2D[] hit=Physics2D.OverlapCircleAll(transform.position,0.7f);
        foreach(Collider2D c in hit)
        {
            Character character=c.GetComponent<Character>();
            if(character!=null)
            {
                character.TakeDamage(damage);
                hitDetected=true;
                break;
            }
        }
        if(hitDetected)
        Destroy(gameObject);
   
    }
}
