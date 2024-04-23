using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDCurrency : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public TowerBlueprint tower;

    private Enemy enemy;

    public static HUDCurrency Instance;

    void Start()
    {
        Instance = this;
        UpdateCurrency();
    }

    // public void DecreaseCurrency()
    // {
    //     PlayerStats.Money -= tower.cost;
    //     PlayerStats.Money -= tower.upgradeCost;
    //     if(PlayerStats.Money < 0)
    //     {
    //         PlayerStats.Money = 0;
    //     }
    //     UpdateCurrency();
    // }

    public void UpdateCurrency()
    {
        currencyText.text = "$" + PlayerStats.Money.ToString();

        if(PlayerStats.Money <= 0)
        {
            PlayerStats.Money = 0;
        }
    }

    void Update()
    {
        UpdateCurrency();
    }
}
