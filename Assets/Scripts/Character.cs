using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp=100;
    public int currentHp=100;
    [SerializeField] StatusBar hpBar;
    [HideInInspector] public Level level;
    [HideInInspector] public Coins coins;

    private void Awake()
    {
        level = GetComponent<Level>();
        coins = GetComponent<Coins>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp,maxHp);
    }

    public void TakeDamage(int damage)
    {
        currentHp-=damage;
        if (currentHp <= 0)
        {
            Debug.Log("RIP");
        }
        hpBar.SetState(currentHp,maxHp);
    }


    public void Heal(int amount)
    {
        if(currentHp <= 0)
            return;

        currentHp+=amount;
        if(currentHp > maxHp)
            currentHp=maxHp;
        hpBar.SetState(currentHp,maxHp);
    }
}
