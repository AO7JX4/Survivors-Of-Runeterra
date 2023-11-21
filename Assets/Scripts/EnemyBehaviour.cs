using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour,IDamagable
{
     protected Transform targetDestination;
     protected GameObject targetGameObject;
     protected Character  targetCharacter;
     [SerializeField] protected float speed;
     [SerializeField] protected int hp = 999;
     [SerializeField] protected int experience_reward = 400;
     public abstract void SetTarget(GameObject target);
     public abstract void Attack();
     public abstract void TakeDamage(int damage);

    

}
