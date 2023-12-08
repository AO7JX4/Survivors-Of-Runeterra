using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOrbManager : MonoBehaviour
{
    public WeaponData wd;
    List<GameObject> fireOrbs;
    [SerializeField] Transform fireOrbsContainer;

    public void Start()
    {
        fireOrbs = new List<GameObject>();
    }

    public void SpawnOrbs()
    {
        for(int i = 0; i < wd.stats.numberOfAttacks; i++)
        {
            GameObject fireOrb = Instantiate(wd.weaponBasePrefab, fireOrbsContainer);
            fireOrbs.Add(fireOrb);
        }
    }

    public void DestroyOrbs()
    {
        for(int i = 0; i < fireOrbs.Count; i++)
        {
            Destroy(fireOrbs[i]);
        }
    }

    public IEnumerator AttackCooldown()
    {
        while (true)
        {
            SpawnOrbs();
            yield return new WaitForSeconds(wd.stats.uptime);

            DestroyOrbs();
            yield return new WaitForSeconds(wd.stats.downtime);
        }
    }
}
