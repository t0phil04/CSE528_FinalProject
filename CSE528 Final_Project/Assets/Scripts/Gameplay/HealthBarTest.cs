using Unity.FPS.UI;
using UnityEngine;

public class HealthBarTest : MonoBehaviour
{
    public float attackInterval = 1f;
    public int attackDamage = 10;

    private HUDHealthBar HUDHealthBar;

    private float timer = 0f;

    void Start()
    {
        // Find the PlayerHealthBar component in the scene
        HUDHealthBar = FindObjectOfType<HUDHealthBar>();

        // If PlayerHealthBar component not found, log an error
        if (HUDHealthBar == null)
        {
            Debug.LogError("PlayerHealthBar component not found in the scene.");
        }
    }

    void Update()
    {
        // Timer to simulate enemy attacks
        timer += Time.deltaTime;
        if (timer >= attackInterval)
        {
            // Reset timer
            timer = 0f;

            // Attack the player
            if (HUDHealthBar != null)
            {
                HUDHealthBar.DecreaseHealth(attackDamage);
            }
        }
    }
}
