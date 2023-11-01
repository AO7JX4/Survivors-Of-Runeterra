using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour, IPickUpObject
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int damage=5;

     public void SetDirection(float dir_x, float dir_y)
     {
        direction = new Vector3(dir_x, dir_y);
     }

    public void OnPickUp(Character character)
    {
       character.TakeDamage(damage);
    }

    void Update()
    {
        transform.position+=direction*speed*Time.deltaTime;
    }
}
