using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiateTower : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject prefabToSpawn;
    private GameObject spawnedObject;
    private bool isMoving = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Spawn the prefab and enable movement
        spawnedObject = Instantiate(prefabToSpawn, GetWorldPosition(eventData.position), Quaternion.identity);
        isMoving = true;
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
        // Disable movement when the pointer is lifted
        isMoving = false;
    }

    private Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        float distance = (37f - Camera.main.transform.position.y) / Mathf.Cos((Mathf.PI / 180f) * Vector3.Angle(ray.direction, Vector3.down));
        return ray.GetPoint(distance);
    }
}
