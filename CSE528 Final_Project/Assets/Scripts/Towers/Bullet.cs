using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform targetEnemy = null;

    public int bulletDamage = 10;
    public float moveSpeed = 10;
    public GameObject explodeEffect;
    // Reference to the AudioManager script
    public AudioManager audioManager;

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(targetEnemy.transform);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void SetTargetEnemy(Transform _targetEnemy)
    {
        targetEnemy = _targetEnemy;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);

            // Check if AudioManager reference is valid
            if (audioManager != null)
            {
                Debug.Log("AudioManager reference is valid.");
                // Play damage hit sound
                audioManager.PlayDamageBulletSound();
            }
            else
            {
                Debug.LogWarning("AudioManager reference is null. Audio will not play.");
            }

            GameObject explodeEffectObj = Instantiate(explodeEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explodeEffectObj, 1f);
        }
    }
}
