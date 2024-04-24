using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour
{
    [Tooltip("Image component displaying current health")]
    public Image HealthFillImage;

    public TextMeshProUGUI roundText;

    public float maxHealth = 100;
    private float currentHealth;

    public int startMoney = 500;

    public static HUDHealthBar Instance;

    public GameObject successPanel;
    public GameObject failPanel;

    // Reference to the Audio Manager script
    public AudioManager audioManager;

    void Start()
    {
        Instance = this;
        PlayerStats.Money = startMoney;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Method to decrease player's health
    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
        if (currentHealth == 0)
        {
            failPanel.SetActive(true);
            Time.timeScale = 0;
        }

        // Play damage tick sound
        audioManager.PlayDamageTickSound();
    }

    // Update the health bar display
    private void UpdateHealthBar()
    {
        HealthFillImage.fillAmount = currentHealth / maxHealth;
    }
}
