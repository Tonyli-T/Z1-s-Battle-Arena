using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSkill : MonoBehaviour
{
	public GameObject bullet;
	public GameObject ult_Bullet;

	private SpriteRenderer SpriteRenderer;
	private GameObject currentBullet;
	private AudioSource soundPlayer;
	public AudioClip skill_Q;

	public float shootSpeed = 5;
	public bool allowQ = true;
	public bool lockQ = false;
	public float startTimeQ;

	void Start()
	{
		soundPlayer = GetComponent<AudioSource>();
		SpriteRenderer = GetComponent<SpriteRenderer>();
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

			soundPlayer.clip = skill_Q;
			soundPlayer.Play();

			SpriteRenderer.color = new Color(0, 1, 0, .5f);
			allowQ = false;
			lockQ = true;
			startTimeQ = Time.time;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			currentBullet = Instantiate(ult_Bullet, transform.position, transform.rotation);
			currentBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * shootSpeed);
			currentBullet.GetComponent<BulletBehaviour>().damage = GetComponent<Stats>().damage;
		}

		// Controlling the freeze time for Q
		if (!allowQ && Time.time - startTimeQ >= 5)
		{
			allowQ = true;
		}
		else if (!allowQ && Time.time - startTimeQ >= 2 && lockQ)
		{
			gameObject.GetComponent<Stats>().magicResist -= 50;
			gameObject.GetComponent<Stats>().armor -= 50;
			gameObject.GetComponent<Stats>().damage -= 50;
			SpriteRenderer.color = new Color(1, 1, 1, 1);
			lockQ = false;
		}	
	}

	// Melle attack for Royal Knight
	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			currentBullet = Instantiate(bullet, transform.position, transform.rotation);
			currentBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * shootSpeed);
			currentBullet.GetComponent<BulletBehaviour>().damage = GetComponent<Stats>().damage;
		}
	}
}
