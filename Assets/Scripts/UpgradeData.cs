using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock,
    CharacterSpeedUpgrade,
    CharacterHealthUpgrade
}

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrade Data")]
public class UpgradeData : ScriptableObject
{
    public UpgradeType tpye;
    public string Name;
    public Sprite icon;
    public string description;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;
    public int hp;
    public int speed;
}

