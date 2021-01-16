using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalKnightSkill : MonoBehaviour
{
	private Animator Animator_Royal;
	private AudioSource AudioSource_Royal;
	private SpriteRenderer SpriteRenderer_Royal;

	public AudioClip AudioClip_SkillQ;
	public AudioClip AudioClip_SkillW;
	public AudioClip AudioClip_SkillE;

	public bool attackSignal = false;

	public bool allowQ;
	private float startTimeQ;

	public bool allowW;
	private float startTimeW;

	public bool allowE;
	public bool lockE;
	private float startTimeE;

	void Start()
	{
		Animator_Royal = GetComponent<Animator>();
		AudioSource_Royal = GetComponent<AudioSource>();
		SpriteRenderer_Royal = GetComponent<SpriteRenderer>();
	}
	
	void Update()
	{
		Attack();
		Cast_Spell();
	}
	
	// The method used to cast spells
	void Cast_Spell()
	{
		if (Input.GetKeyDown(KeyCode.Q) && allowQ)
		{
			gameObject.GetComponent<Stats>().magicResist = 100;
			gameObject.GetComponent<Stats>().armor = 100;
			gameObject.transform.GetChild(4).gameObject.SetActive(true);
			AudioSource_Royal.clip = AudioClip_SkillQ;
			AudioSource_Royal.Play();

			allowQ = false;
			startTimeQ = Time.time;
		}
		if (Input.GetKeyDown(KeyCode.W) && allowW)
		{
			gameObject.transform.position += new Vector3(5, 0, 0);
			AudioSource_Royal.clip = AudioClip_SkillW;
			AudioSource_Royal.Play();

			allowW = false;
			startTimeW = Time.time;
		}
		if (Input.GetKeyDown(KeyCode.E) && allowE)
		{
			gameObject.GetComponent<Stats>().health += 200;
			gameObject.GetComponent<Stats>().damage += 200;
			SpriteRenderer_Royal.color = Color.red;
			AudioSource_Royal.clip = AudioClip_SkillE;
			AudioSource_Royal.Play();

			allowE = false;
			lockE = true;
			startTimeE = Time.time;
		}

		// Controlling the freeze time for Q
		if (allowQ == false && Time.time - startTimeQ >= 5)
		{
			allowQ = true;
		}
		else if (allowQ == false && Time.time - startTimeQ >= 1)
		{
			gameObject.GetComponent<Stats>().magicResist = 10;
			gameObject.GetComponent<Stats>().armor = 20;
			gameObject.transform.GetChild(4).gameObject.SetActive(false);
		}

		// Controlling the freeze time for W
		if (allowW == false && Time.time - startTimeW >= 10)
		{
			allowW = true;
		}

		// Controlling the freeze time for E
		if (allowE == false && Time.time - startTimeE >= 5 && lockE)
		{
			gameObject.GetComponent<Stats>().health -= 200;
			gameObject.GetComponent<Stats>().damage -= 200;
			SpriteRenderer_Royal.color = Color.white;

			lockE = false;
		}
		else if (allowE == false && Time.time - startTimeE >= 30)
		{
			allowE = true;
		}
	}

	// Melle attack for Royal Knight
	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			attackSignal = true;
			Animator_Royal.SetBool("IsAttacking", true);
		}
		else
		{
			//Animator_Royal.SetBool("IsAttacking", false);
		}
	}

	// Calculating damage
	private void OnTriggerStay2D(Collider2D collision)
	{
	/*	if (attackSignal)
		{*/
			//collision.gameObject.GetComponent<Stats>().health -= gameObject.GetComponent<Stats>().damage;
			//Debug.Log(true);
			//attackSignal = false;
		/*}*/
	}
}
