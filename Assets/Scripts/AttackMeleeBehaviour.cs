using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeBehaviour : MonoBehaviour
{
	private AudioSource AudioSource;
	private Animator Animator;
	private Rigidbody2D Rigidbody2D;

	private string type;

	// Start is called before the first frame update
	void Start()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		AudioSource = GetComponent<AudioSource>();
		Animator = GetComponent<Animator>();

		type = GetComponent<ObjectInfoBehaviour>().type;
		AudioSource.mute = true;
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		var damage = GetComponent<Stats>().damage;
		var selfFaction = GetComponent<ObjectInfoBehaviour>().faction;

		var collisionStats = collision.collider.GetComponent<Stats>();
		var collisionFaction = collision.collider.GetComponent<ObjectInfoBehaviour>().faction;

		Rigidbody2D.velocity = new Vector2(0, 0);

		if ((selfFaction == "Team Red" && collisionFaction == "Team Blue") || (selfFaction == "Team Blue" && collisionFaction == "Team Red"))
		{
			Debug.Log(true);
			if ((type == "Hero" && Input.GetKeyDown(KeyCode.A)) || (type == "Creep"))
			{
				collisionStats.health -= damage * Time.deltaTime;
				Animator.SetBool("IsAttacking", true);
				AudioSource.mute = false;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Animator.SetBool("IsAttacking", false);
		AudioSource.mute = true;
	}
}
