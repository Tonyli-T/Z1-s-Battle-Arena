using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
	public Rigidbody2D rb2D;
	public float rotateDegrees;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Attack();
	}

	// Player choose to attack by pressing A on the keyboard
	void Attack()
	{
		// Basic attack
		if (Input.GetKeyDown(KeyCode.A))
		{
			rb2D.MoveRotation(rotateDegrees);
		}

		// Cancel current action
		if (Input.GetKeyDown(KeyCode.S))
		{

		}

		// skill 1
		if (Input.GetKeyDown(KeyCode.Q))
		{

		}

		// Ult
		if (Input.GetKeyDown(KeyCode.W))
		{

		}

		// Card-based skill
		if (Input.GetKeyDown(KeyCode.E))
		{

		}
	}
}
