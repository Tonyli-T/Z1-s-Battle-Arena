using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	private Rigidbody2D rb2d;
	public float velocity;
	public float xAxis;
	public float yAxis;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		xAxis = Input.GetAxis("Horizontal");
		yAxis = Input.GetAxis("Vertical");
		rb2d.AddForce(Vector2.right * xAxis * velocity, ForceMode2D.Impulse);
		rb2d.AddForce(Vector2.up * yAxis * velocity, ForceMode2D.Impulse);
		rb2d.velocity = new Vector2(xAxis * velocity, yAxis * velocity);
	}
}