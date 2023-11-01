using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cast_Spell_Yasuo_AA : MonoBehaviour
{
    [SerializeField] float attackSpeed=4f;
    float currentCoolDown;
    
    [SerializeField] GameObject slash;
    [SerializeField] Image img;

    private void Awake()
    {
        img.fillAmount=0;
    }


    private void Update()
    {
        currentCoolDown-=Time.deltaTime;
        img.fillAmount-=1/attackSpeed*Time.deltaTime;
        if (currentCoolDown < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        currentCoolDown=attackSpeed;
        img.fillAmount=1;
        GameObject closestEnemy = FindClosestEnemy();
    
        if (closestEnemy != null)
        {
            Vector3 directionToEnemy = closestEnemy.transform.position - transform.position;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x);
            slash.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
            Vector3 newPosition=transform.position+directionToEnemy.normalized*2f;
            slash.transform.position=newPosition;
        }
        slash.SetActive(true);
    }

    private GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            return null;
        }

        float closestDistance = Mathf.Infinity;
        for(int i=0; i<enemies.Length; i++)
        {
             float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
             if (distance < closestDistance)
             {
                 closestDistance = distance;
                 closestEnemy = enemies[i];
             }
        }
        return closestEnemy;
    }
}
