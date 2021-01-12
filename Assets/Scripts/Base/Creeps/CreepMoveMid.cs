﻿using UnityEngine;

public class CreepMoveMid : MonoBehaviour
{
	private GameObject enemyBase;
	private Rigidbody2D rb2D;
	public float speed = 5;
	public float damage = 5;

	// Start is called before the first frame update
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();

		if (gameObject.CompareTag("太阳圣殿"))
		{
			enemyBase = GameObject.Find("奥姆真理");
		}
		else if (gameObject.CompareTag("奥姆真理"))
		{
			enemyBase = GameObject.Find("太阳圣殿");
		}
	}

	// Update is called once per frame
	void Update()
	{
		var moveTowards = enemyBase.transform.position - transform.position;
		rb2D.AddForce(moveTowards.normalized * speed, ForceMode2D.Force);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		rb2D.velocity = new Vector2(0, 0);

		if (gameObject.CompareTag("太阳圣殿"))
		{
			if (collision.CompareTag("奥姆真理"))
			{
				collision.GetComponent<BaseStats>().currentHealth -= damage * Time.deltaTime;
			}
		}
		else if (gameObject.CompareTag("奥姆真理"))
		{
			if (collision.CompareTag("太阳圣殿"))
			{
				collision.GetComponent<BaseStats>().currentHealth -= damage * Time.deltaTime;
			}
		}
	}
}
