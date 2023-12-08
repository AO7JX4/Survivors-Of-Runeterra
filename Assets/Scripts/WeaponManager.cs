using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;

    public List<WeaponBase> weapons;

    public void Awake()
    {
        weapons = new List<WeaponBase>();
    }

    public void AddWeapon(WeaponData weaponData)
    {

        GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

        WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

        weaponBase.SetData(weaponData);
        weapons.Add(weaponBase);

        Level lvl = GetComponent<Level>();
        if(lvl != null)
        {
            lvl.AddUpgradesIntoTheListOfAvailableUpgrades(weaponData.upgrades);
        }

    }

    internal void UpgradeWeapon(UpgradeData upgradeData)
    {
        WeaponBase weaponToUpgrade = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);
        weaponToUpgrade.Upgrade(upgradeData);
    }
}
