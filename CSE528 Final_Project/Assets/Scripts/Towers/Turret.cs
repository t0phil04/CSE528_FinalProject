using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Turret : MonoBehaviour 
{
    private Transform firePoint = null;
    private Transform rotationAxis; 
    private float timer = 0;
    
    public float attack_CD_Time = 1;//�������
    
    public List<GameObject> enemyList = new List<GameObject> ();//������Χ�ڵĵ���
    public GameObject bullet;//����ʱ������ӵ�

    void Start () 
    {
        rotationAxis = transform.Find ("RotationAxis");
        firePoint = rotationAxis.transform.Find("FirePoint");
        timer = attack_CD_Time;//��������ʱ�е��˻ṥ��һ��
    }
    
    void Update()
    {
        UpdateEnemyList();
        timer += Time.deltaTime;
        if (enemyList.Count > 0)
        {
            Vector3 pos = enemyList[0].transform.position;
            pos.y = rotationAxis.position.y;
            rotationAxis.LookAt(pos);
        }
        if (timer >= attack_CD_Time && enemyList.Count > 0)
        {
            AttackEnemy();
            timer = 0;
        }
    }
    
    void UpdateEnemyList()
    {
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            if (enemyList[i] == null)
                enemyList.RemoveAt(i);
        }
    }
    
    void AttackEnemy()
    {
        if (enemyList.Count > 0)
        {
            GameObject bulletObj = Instantiate(bullet, firePoint.position, firePoint.rotation);
            bulletObj.GetComponent<Bullet>().SetTargetEnemy(enemyList[0].transform);
        } 
        else 
        {
            timer = attack_CD_Time;
        }
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy" && !enemyList.Contains(collider.gameObject))
            enemyList.Add(collider.gameObject);
    }
    
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Enemy" && enemyList.Contains(collider.gameObject))
            enemyList.Remove(collider.gameObject);
    }
}