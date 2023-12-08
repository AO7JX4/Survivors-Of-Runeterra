using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingOrb : WeaponBase
{
    Transform player;
    public float orbitSpeed = 5f;
    public float orbitRadius = 1.5f;

    public void Start()
    {
        player = transform.root;
        StartCoroutine(AttackCooldown());
    }

    public void Update()
    {
        Attack();
    }

    public override void Attack()
    {
        float angle = Time.time * orbitSpeed;
        float x = Mathf.Cos(angle) * orbitRadius;
        float y = Mathf.Sin(angle) * orbitRadius;

        transform.position = player.position + new Vector3(x, y, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canAttack)
        {
            EnemyBehaviour e = collision.GetComponent<EnemyBehaviour>();
            if (e != null)
            {
                e.TakeDamage(weaponStats.damage);
            }
        }
    }

    public IEnumerator AttackCooldown()
    {
        SpriteRenderer spriteRenderer = GetComponent<WeaponBase>().GetComponentInChildren<SpriteRenderer>();
        while (true)
        {
            // Orb is visible for 2 seconds
            canAttack = true;
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(weaponStats.uptime);

            // Orb is not visible for 3 seconds
            canAttack = false;
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(weaponStats.downtime);
        }
    }
}
