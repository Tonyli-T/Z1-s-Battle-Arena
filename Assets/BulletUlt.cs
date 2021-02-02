using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUlt : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		var stats = collision.GetComponent<Stats>();

		if (stats != null)
		{
			stats.health *= 0.25f;
			Destroy(gameObject);
		}
	}
}
