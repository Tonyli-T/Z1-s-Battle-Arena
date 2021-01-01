using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
	public Rigidbody2D rb2d;
	public float velocity;
	public Vector2 destination;
	public Vector2 relativeDestination;

	void Start()
	{
		destination = (Vector2)Camera.main.WorldToScreenPoint(transform.position);
	}

	void Update()
	{
		Move();
	}

	void Move()
	{
		if (Input.GetMouseButtonDown(0))
		{
			destination = Input.mousePosition;
		}

		relativeDestination = destination - (Vector2)Camera.main.WorldToScreenPoint(transform.position);

		// Stop moving, if the player get close to the target
		if (relativeDestination.magnitude <= 5)
		{
			rb2d.velocity = Vector2.zero;
		}
		else
		{
			rb2d.AddForce(relativeDestination.normalized * velocity * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
