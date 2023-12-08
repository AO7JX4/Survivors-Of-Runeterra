using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Yasuo_T : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int damage = 5;

    public float getSpeed()
    {
        return speed;
    }

    public Vector3 getDirection()
    {
        return direction;
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour e = collision.GetComponent<EnemyBehaviour>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
