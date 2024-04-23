using System;
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
    public Button closeButton;

    public Turret currentTurret;
    
    // public bool isUpgraded = false;

    public TextMeshProUGUI upgradeText;
    public TextMeshProUGUI sellText;

    private int upgradeMoney;
    private int sellMoney;
    private void Awake()
    {
        closeButton.onClick.AddListener(() =>
        {
            UpgradeSellUI.gameObject.SetActive(false);
        });
        upgradeButton.onClick.AddListener(() =>
        {
            if (upgradeMoney == 0)
                return;
            
            if (PlayerStats.Money < upgradeMoney)
            {
                Debug.Log("Not enough money to upgrade that!");
                return;
            }
            
            // Subtract upgrade cost from player's money balance
            PlayerStats.Money -= upgradeMoney;
            var upgradeTurretObj = Instantiate(currentTurret.towerBlueprint.nextInstantiateTower.prefabToSpawn,
                currentTurret.transform.position, Quaternion.identity);
            var upgradeTurret = upgradeTurretObj.GetComponent<Turret>();
            upgradeTurret.towerBlueprint = currentTurret.towerBlueprint.nextInstantiateTower.tower;
            Destroy(currentTurret.gameObject);
            
            UpgradeSellUI.gameObject.SetActive(false);
            Debug.Log("Tower upgraded!");
        });
        sellButton.onClick.AddListener(() =>
        {
            PlayerStats.Money += sellMoney;
            Destroy(currentTurret.gameObject);
            UpgradeSellUI.gameObject.SetActive(false);
        });
    }
    // // Start is called before the first frame update
    // void Start()
    // {
    //     // find Canvas in scene
    //     UpgradeSellUI = GameObject.Find("UpgradeSellUI").GetComponent<Canvas>();
    // }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
    
            if (hits.Length > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    GameObject hitObject = hit.collider.gameObject;

                    if (!hitObject.name.Equals("RotationAxis"))
                        continue;

                    currentTurret = hitObject.transform.parent.GetComponent<Turret>();
                    if (!currentTurret.enabled) continue;
                    // find Turret
                    upgradeMoney = currentTurret.towerBlueprint.upgradeCost;
                    sellMoney = currentTurret.towerBlueprint.sellCost;
                    FormatUpgradeText(upgradeMoney);
                    FormatSellText(sellMoney);
                    
                    // Tower clicked! Show UpgradeSellUI
                    UpgradeSellUI.transform.position =
                        currentTurret.transform.position + Vector3.up * 3f + Vector3.forward * 5f;
                    UpgradeSellUI.gameObject.SetActive(true);
                    
                }
            }
        }
    }


    // void OnMouseDown()
    // {
    //     if (UpgradeSellUI != null)
    //     {
    //         // Tower clicked! Show UpgradeSellUI
    //         UpgradeSellUI.transform.position = transform.position + Vector3.up * 3f;
    //         UpgradeSellUI.transform.position = transform.position + Vector3.forward * 5f;
    //         UpgradeSellUI.gameObject.SetActive(true);
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Possible UpgradeSellUI Error... Proceed cautiously!");
    //     }
    // }

    // public void HideUI()
    // {
    //     UpgradeSellUI.gameObject.SetActive(false);
    // }

    // public void UpgradeTower()
    // {
    //     if (PlayerStats.Money < tower.upgradeCost)
    //     {
    //         Debug.Log("Not enough money to upgrade that!");
    //         return;
    //     }
    //
    //     // Subtract upgrade cost from player's money balance
    //     PlayerStats.Money -= tower.upgradeCost;
    //
    //     Debug.Log("Tower upgraded!");
    // }

    public void SellTower()
    {

    }


    void FormatUpgradeText(int value)
    {
        if (value == 0)
            upgradeText.text = "HIGHEST";
        else
            upgradeText.text = "UPGRADE\n$" + value;
    }

    void FormatSellText(int value)
    {
        sellText.text = "SELL\n$" + value;
    }
}