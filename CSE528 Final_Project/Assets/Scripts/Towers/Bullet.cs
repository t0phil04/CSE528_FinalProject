using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private Transform targetEnemy = null;
    
    public int bulletDamage = 10;
    public float moveSpeed=10;
    public GameObject explodeEffect;
    
    void Update ()  
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt (targetEnemy.transform);
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
            GameObject explodeEffectObj = Instantiate(explodeEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explodeEffectObj, 1f);
        }
    }
}