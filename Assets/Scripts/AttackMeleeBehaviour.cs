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
		var selfFaction = GetComponent<ObjectInfoBehaviour>().faction;
		var collisionObjectInfo = collision.gameObject.GetComponent<ObjectInfoBehaviour>();

		if (collisionObjectInfo != null
			&& ((selfFaction == "Team Red" && collisionObjectInfo.faction == "Team Blue") || (selfFaction == "Team Blue" && collisionObjectInfo.faction == "Team Red"))
			&& ((type == "Hero" && Input.GetKeyDown(KeyCode.A)) || (type == "Creep")))
		{
			Rigidbody2D.velocity = new Vector2(0, 0);

			var damage = GetComponent<Stats>().damage;
			var collisionStats = collision.gameObject.GetComponent<Stats>();

			collisionStats.health -= damage * Time.deltaTime;
			Animator.SetBool("IsAttacking", true);
			AudioSource.mute = false;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		Animator.SetBool("IsAttacking", false);
		AudioSource.mute = true;
	}

/*	private void OnTriggerStay2D(Collider2D collision)
	{
		Debug.Log(true);
	}*/
}
