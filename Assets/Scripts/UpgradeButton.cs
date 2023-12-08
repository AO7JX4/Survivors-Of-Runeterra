using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI Name;
    [SerializeField] TextMeshProUGUI description;

    public void Set(UpgradeData upgradeData)
    {
        image.sprite = upgradeData.icon;
        Name.text = upgradeData.Name;
        description.text = upgradeData.description;
    }

    public void Clean()
    {
        image.sprite = null;
        Name.text = null;
        description.text = null;
    }
}
