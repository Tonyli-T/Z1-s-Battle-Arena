using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public float health;
	public float damage;
	public float magicResist;
	public float armor;

	private void Update()
	{
		if (health <= 0)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
