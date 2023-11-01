using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Yasuo_AA : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour e=collision.GetComponent<EnemyBehaviour>();
        if (e!=null)
        {
            e.TakeDamage(damage);
            GetComponentInParent<Cast_Spell_Yasuo_T>().addStack();
        }
    }
}
