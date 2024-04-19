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

    public static HUDHealthBar Instance;
    void Start()
    {
        Instance = this;
        
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
    }

    // Update the health bar display
    private void UpdateHealthBar()
    {
        HealthFillImage.fillAmount = currentHealth / maxHealth;
    }
}
