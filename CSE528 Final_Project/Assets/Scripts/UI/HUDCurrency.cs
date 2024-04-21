using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDCurrency : MonoBehaviour
{
    public TextMeshProUGUI currencyText;

    public TowerBlueprint tower;

    public static HUDCurrency Instance;

    void Start()
    {
        Instance = this;

        PlayerStats.Money = 500;
        UpdateCurrency();
    }

    public void DecreaseCurrency()
    {
        PlayerStats.Money -= tower.cost;
        if(PlayerStats.Money < 0)
        {
            PlayerStats.Money = 0;
        }
        UpdateCurrency();
    }

    public void UpdateCurrency()
    {
        currencyText.text = "$" + PlayerStats.Money.ToString();

        if(PlayerStats.Money <= 0)
        {
            PlayerStats.Money = 0;
        }
    }
}