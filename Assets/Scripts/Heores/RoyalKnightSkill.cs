using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalKnightSkill : MonoBehaviour
{
	public bool allowAttack;

	public bool allowQ;
	public float startTimeQ;
	public float currentTimeQ;

	public bool allowW;
	public float startTimeW;
	public float currentTimeW;

	public bool allowE;
	public bool lockE;
	public float startTimeE;
	public float currentTimeE;	

	private void Start()
	{
		
	}
	
	private void Update()
	{
		attack();
		cast();
	}
	
	// The method used to cast spells
	void cast()
	{
		// Pressing the keys
		if (Input.GetKeyDown(KeyCode.Q) && allowQ)
		{
			gameObject.GetComponent<Stats>().magicResist = 100;
			gameObject.GetComponent<Stats>().armor = 100;

			allowQ = false;
			startTimeQ = Time.realtimeSinceStartup;
		}
		if (Input.GetKeyDown(KeyCode.W) && allowW)
		{
			gameObject.transform.position += new Vector3(5, 0, 0);

			allowW = false;
			startTimeW = Time.realtimeSinceStartup;
		}
		if (Input.GetKeyDown(KeyCode.E) && allowE)
		{
			gameObject.GetComponent<Stats>().health += 200;
			gameObject.GetComponent<Stats>().damage += 200;
			gameObject.transform.localScale += new Vector3(1, 1, 0);

			allowE = false;
			lockE = true;
			startTimeE = Time.realtimeSinceStartup;
		}

		// Controlling the freeze time for Q
		if (allowQ == false && Time.realtimeSinceStartup - startTimeQ >= 1)
		{
			gameObject.GetComponent<Stats>().magicResist = 10;
			gameObject.GetComponent<Stats>().armor = 20;
		}
		if (allowQ == false && Time.realtimeSinceStartup - startTimeQ >= 5)
		{
			allowQ = true;
		}

		// Controlling the freeze time for W
		if (allowW == false && Time.realtimeSinceStartup - startTimeW >= 10)
		{
			allowW = true;
		}

		// Controlling the freeze time for E
		if (allowE == false && Time.realtimeSinceStartup - startTimeE >= 5 && lockE)
		{
			gameObject.GetComponent<Stats>().health -= 200;
			gameObject.GetComponent<Stats>().damage -= 200;
			gameObject.transform.localScale -= new Vector3(1, 1, 0);
			lockE = false;
		}
		if (allowE == false && Time.realtimeSinceStartup - startTimeE >= 30)
		{
			allowE = true;
		}
	}

	// Melle attack for Royal Knight
	void attack()
	{
		if (Input.GetKeyDown(KeyCode.A) && allowAttack)
		{
			allowAttack = false;
		}
	}

	// Calculating damage
	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.gameObject.GetComponent<Stats>().health -= gameObject.GetComponent<Stats>().damage;
	}
}
