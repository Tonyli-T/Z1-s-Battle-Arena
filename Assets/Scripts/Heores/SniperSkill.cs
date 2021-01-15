using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSkill : MonoBehaviour
{
	public GameObject bullet;
	private GameObject currentBullet;

	public bool allowQ;
	public float startTimeQ;
	public float currentTimeQ;

	void Start()
	{
		
	}

	void Update()
	{
		Attack();
		Cast_Spell();
	}

	// The method used to cast spells
	void Cast_Spell()
	{
		// Pressing the keys
		if (Input.GetKeyDown(KeyCode.Q) && allowQ)
		{
			gameObject.GetComponent<Stats>().magicResist += 50;
			gameObject.GetComponent<Stats>().armor += 50;
			gameObject.GetComponent<Stats>().damage += 50;

			allowQ = false;
			startTimeQ = Time.time;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			
		}

		// Controlling the freeze time for Q
		if (allowQ == false && Time.time - startTimeQ >= 2)
		{
			gameObject.GetComponent<Stats>().magicResist -= 50;
			gameObject.GetComponent<Stats>().armor -= 50;
			gameObject.GetComponent<Stats>().damage -= 50;
		}
		else if (allowQ == false && Time.time - startTimeQ >= 5)
		{
			allowQ = true;
		}
	}

	// Melle attack for Royal Knight
	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			currentBullet = Instantiate(bullet, transform.position, transform.rotation);
			currentBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 2));
		}
	}
}
