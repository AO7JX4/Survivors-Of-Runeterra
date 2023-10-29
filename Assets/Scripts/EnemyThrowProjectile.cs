using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowProjectile : MonoBehaviour
{
   [SerializeField] float timeToAttack;
   float timer;
   [SerializeField] GameObject projectile;
   GameObject targetGameObject;
   Transform targetDestination;
   
    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = targetGameObject.transform;
    }
    
    
    private void Update()
    {
       
        if(timer<timeToAttack)
        {
            timer+=Time.deltaTime;
            return;
        }

        timer=0;
        SpawnProjectile();

    }

    private void SpawnProjectile()
    {
        Vector3 direction=(targetDestination.position-transform.position).normalized;
        GameObject newProjectile=Instantiate(projectile);
        newProjectile.transform.position=transform.position;
        newProjectile.GetComponent<EnemyProjectile>().SetDirection(direction.x,direction.y);
    }
}
