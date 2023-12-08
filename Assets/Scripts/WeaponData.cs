using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class WeaponStats
{
    public int damage;
    public float downtime;
    public float uptime;
    public int numberOfAttacks;

    public WeaponStats(int damage, float downtime, float uptime, int numberOfAttacks)
    {
        this.damage = damage;
        this.downtime = downtime;
        this.uptime = uptime;
        this.numberOfAttacks = numberOfAttacks;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.uptime += weaponUpgradeStats.uptime;
        this.downtime += weaponUpgradeStats.downtime;
        this.numberOfAttacks += weaponUpgradeStats.numberOfAttacks;
    }
}


[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
