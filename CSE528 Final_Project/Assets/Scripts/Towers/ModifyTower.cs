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

    public void UpgradeTower()
    {

    }

    public void SellTower()
    {

    }
}