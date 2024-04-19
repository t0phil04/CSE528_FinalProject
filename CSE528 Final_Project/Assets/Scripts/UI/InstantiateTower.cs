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
        spawnedObject.GetComponent<Turret>().enabled = false;
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
        spawnedObject.GetComponent<Turret>().enabled = true;
    }

    private Vector3 GetWorldPosition(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        float distance = (Camera.main.transform.position.y - 0.345f) / Mathf.Cos((Mathf.PI / 180f) * Vector3.Angle(ray.direction, Vector3.down));
        return ray.GetPoint(distance);
    }
}
