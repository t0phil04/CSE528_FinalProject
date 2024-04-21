using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiateTower : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject prefabToSpawn;
    private GameObject spawnedObject;
    private bool isMoving = false;

    public TowerBlueprint tower;

    public HUDCurrency hudCurrency;


    public void OnPointerDown(PointerEventData eventData)
    {
        // If the player has enough money to afford a specific tower, Spawn the prefab and enable movement
        if (PlayerStats.Money >= tower.cost)
        {
            spawnedObject = Instantiate(prefabToSpawn, GetWorldPosition(eventData.position), Quaternion.identity);
            spawnedObject.GetComponent<Turret>().enabled = false;
            isMoving = true;
        }
        // If the player does not have enough money to afford a tower, print to the console that there are insufficient funds, and disallow movement.
        else
        {
            Debug.Log("Insufficient funds.");
            return;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the spawned object
        if (isMoving)
        {
            spawnedObject.transform.position = GetWorldPosition(eventData.position);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        // If spawnedObject is null, return to avoid NullReferenceException
        if (spawnedObject == null)
        {
            Debug.LogWarning("spawnedObject is null in OnPointerUp.");
            return;
        }

        // Disable movement when the pointer is lifted
        isMoving = false;

        // Enable the Turret component if spawnedObject is not null
        Turret turret = spawnedObject.GetComponent<Turret>();
        if (turret != null)
        {
            turret.enabled = true;
        }
        else
        {
            Debug.LogWarning("Turret component not found on spawnedObject.");
        }

        // If the player has the sufficient funds, subtract the cost of the tower from the player's wallet, and then print that the tower has been purchased to the console.
        if (PlayerStats.Money >= tower.cost)
        {
            PlayerStats.Money -= tower.cost;
            Debug.Log("Turret Purchased.");
        }
        else
        {
            Debug.Log("You can't place a tower yet!"); // player does not have the sufficient funds for the tower they tried to purchase/place.
            return;
        }

        // Update currency UI
        hudCurrency.UpdateCurrency();
    }

    private Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        float distance = (Camera.main.transform.position.y - 0.345f) / Mathf.Cos((Mathf.PI / 180f) * Vector3.Angle(ray.direction, Vector3.down));
        return ray.GetPoint(distance);
    }
}