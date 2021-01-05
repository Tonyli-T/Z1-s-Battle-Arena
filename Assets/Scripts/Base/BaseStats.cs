using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{  
    public float maxHealth;
    public float currentHealth;

	private void Update()
	{
		if (currentHealth <= 0)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
 