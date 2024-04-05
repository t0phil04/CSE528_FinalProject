using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour
{
    [Tooltip("Image component displaying current health")]
    public Image HealthFillImage;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Method to decrease player's health
    public void DecreaseHealth(int amount)
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
        HealthFillImage.fillAmount = (float)currentHealth / maxHealth;
    }
}
