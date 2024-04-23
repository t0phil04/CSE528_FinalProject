using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ModifyTower : MonoBehaviour
{
    public Canvas UpgradeSellUI;
    public Button upgradeButton;
    public Button sellButton;

    [HideInInspector]
    public TowerBlueprint tower;
    [HideInInspector]
    public bool isUpgraded = false;


    // Start is called before the first frame update
    void Start()
    {
        // find Canvas in scene
        UpgradeSellUI = GameObject.Find("UpgradeSellUI").GetComponent<Canvas>();
    }

    void OnMouseDown()
    {
        if (UpgradeSellUI != null)
        {
            // Tower clicked! Show UpgradeSellUI
            UpgradeSellUI.transform.position = transform.position + Vector3.up * 3f;
            UpgradeSellUI.transform.position = transform.position + Vector3.forward * 5f;
            UpgradeSellUI.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Possible UpgradeSellUI Error... Proceed cautiously!");
        }
    }

    public void HideUI()
    {
        UpgradeSellUI.gameObject.SetActive(false);
    }

    public void UpgradeTower()
    {
        if (PlayerStats.Money < tower.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        // Subtract upgrade cost from player's money balance
        PlayerStats.Money -= tower.upgradeCost;

        Debug.Log("Tower upgraded!");
    }

    public void SellTower()
    {

    }
}