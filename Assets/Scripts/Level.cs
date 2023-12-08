using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    int level=1;
    int experience=0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradeMenuManager upgradeMenuManager;

    [SerializeField] List<UpgradeData> upgrades;
    [SerializeField] List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> aqquiredUpgrades;

    WeaponManager weaponManager;

    public void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    int TO_LEVEL_UP
    {
        get
        {
            return level*1000;
        }
    }

    private void Start()
    {
         experienceBar.UpdateExperienceSlider(experience,TO_LEVEL_UP);
         experienceBar.SetLevelText(level);
         selectedUpgrades = new List<UpgradeData>();
         aqquiredUpgrades = new List<UpgradeData>();
    }

    public void AddExperience(int amount)
    {
        experience+=amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience,TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if(experience>=TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        if (selectedUpgrades == null)
        {
            selectedUpgrades = new List<UpgradeData>(); ;
        }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));

        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);
        upgradeMenuManager.OpenPanel(selectedUpgrades);
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        HashSet<int> selectedIndices = new HashSet<int>();

        for (int i = 0; i < count; i++)
        {
            int rand;
            do
            {
                rand = Random.Range(0, upgrades.Count);
            } while (!selectedIndices.Add(rand));

            upgradeList.Add(upgrades[rand]);
        }

        return upgradeList;
    }

    public void Upgrade(int selectedUpgradeID)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        switch (upgradeData.tpye)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUpgrade:
                break;
            case UpgradeType.ItemUnlock:
                break;
            case UpgradeType.CharacterHealthUpgrade:
                GetComponentInParent<Character>().Upgrade(upgradeData);
                break;
            case UpgradeType.CharacterSpeedUpgrade:
                GetComponentInParent<PlayerMove>().Upgrade(upgradeData);
                break;
        }

        aqquiredUpgrades.Add(upgradeData);
        upgrades.Remove(upgradeData);
    }

    public void AddUpgradesIntoTheListOfAvailableUpgrades(List<UpgradeData> upgradesToAdd)
    {
        upgrades.AddRange(upgradesToAdd);
    }
}
