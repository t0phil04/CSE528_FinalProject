using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float enemyMoveSpeed = 3;
	public float enemyDamage = 10f;
	public int HP = 500;
	public GameObject enemyExpEffect;
	
	
	private int index = 0;
	private int maxHP = 0;

	private Transform[] points = null;
	private Slider hpSlider = null;

	public int value = 50;
	
	void Start () 
	{
		maxHP = HP;
		points = Waypoints.points;
		hpSlider = GetComponentInChildren<Slider> ();
	}

	void Update()
	{
		if (index >= points.Length)
			return;

		var trans = (points[index].position - this.transform.position).normalized * enemyMoveSpeed * Time.deltaTime;
		transform.Translate(trans);
		
		if (Vector3.Distance(this.transform.position, points[index].position) < 0.3f)
			index++;

		if (index > points.Length - 1)
		{
			Destroy(gameObject);
		}
	}

	void OnDestroy()
	{
		EnemySpawnerManager.currentEnemyCount--;
	}

	public void TakeDamage(int damage)
	{
		if (HP <= 0)
			return;

		HP -= damage;
		hpSlider.value = (float)HP / maxHP;

		if (HP > 0) return;
		Die();
	}

	public void Die()
	{
		GameObject enemyExpGO = Instantiate(enemyExpEffect, transform.position, transform.rotation);
		Destroy(enemyExpGO, 1.5f);
		Destroy(gameObject);

		PlayerStats.Money += value;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("Player"))
		{
			HUDHealthBar.Instance.DecreaseHealth(enemyDamage);
		}
	}
}
