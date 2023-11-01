using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cast_Spell_Yasuo_T : MonoBehaviour
{
    [SerializeField] GameObject tornadoPrefab;
    float currentCoolDown=0;
    [SerializeField] float coolDown=5f;
    [SerializeField] Image img; 
    [SerializeField] Image[] stackImg; 
    int stacks=0;

    public void addStack()
    {
        stacks++;
    }

    private void Awake()
    {
        img.fillAmount=0;
        for(int i=0;i<stackImg.Length;i++)
            stackImg[i].fillAmount=0;
    }

    void Update()
    {
        currentCoolDown-=Time.deltaTime;
        img.fillAmount-=1/coolDown*Time.deltaTime;
        for(int i=0;i<stacks;i++)
        {
             if(i>5)
                break;
            stackImg[i].fillAmount=1;
           
        }
           
        if(Input.GetKeyDown(KeyCode.E) && currentCoolDown<=0 && stacks>=6)
        {
           SpawnTornado();
        }
            
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

    private void SpawnTornado()
    {
        img.fillAmount=1;
        stacks=0;
        for(int i=0;i<stackImg.Length;i++)
            stackImg[i].fillAmount=0;
        currentCoolDown=coolDown;
        GameObject closestEnemy = FindClosestEnemy();
    
        if (closestEnemy != null)
        {
             GameObject tornado=Instantiate(tornadoPrefab);
             tornado.transform.position=transform.position;
             Vector3 direction=(closestEnemy.transform.position-transform.position).normalized;
             tornado.GetComponent<Spell_Yasuo_T>().SetDirection(direction.x,direction.y);

        }
    }
}
