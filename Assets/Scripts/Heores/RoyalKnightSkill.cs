using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalKnightSkill : MonoBehaviour
{
	private CardInfluenceBehaviour CardInfluenceBehaviour;
	private Animator Animator_Royal;
	private AudioSource AudioSource_Royal;
	private SpriteRenderer SpriteRenderer_Royal;

	public AudioClip AudioClip_SkillQ;
	public AudioClip AudioClip_SkillW;
	public AudioClip AudioClip_SkillE;

	public bool attackSignal = false;

	public bool allowQ = true;
	private bool lockQ = false;
	private float startTimeQ;

	public bool allowW = true;
	private bool lockW = false;
	private float startTimeW;

	public bool allowE = true;
	private bool lockE = false;
	private bool lockE2 = false;
	private float startTimeE;

	private float silanceStartTime;
	private bool lockSilance = true;

	void Start()
	{
		Animator_Royal = GetComponent<Animator>();
		AudioSource_Royal = GetComponent<AudioSource>();
		SpriteRenderer_Royal = GetComponent<SpriteRenderer>();
		CardInfluenceBehaviour = GetComponent<CardInfluenceBehaviour>();
	}
	
	void Update()
	{
		CardEffect();
		Attack();
		Cast_Spell();
	}
	
	void CardEffect()
	{
		// Silance
		if (CardInfluenceBehaviour.beingAffectedBySilance && lockSilance)
		{
			silanceStartTime = Time.time;
			allowQ = allowE = allowW = false;
			lockSilance = false;			
		}
		else if (Time.time - silanceStartTime >= 5 && !lockSilance)
		{
			allowQ = allowE = allowW = true;
			CardInfluenceBehaviour.beingAffectedBySilance = false;
			lockSilance = true;
		}
	}

	// The method used to cast spells
	void Cast_Spell()
	{
		// Skill Q
		if (Input.GetKeyDown(KeyCode.Q) && allowQ)
		{
			gameObject.GetComponent<Stats>().magicResist = 100;
			gameObject.GetComponent<Stats>().armor = 100;
			gameObject.transform.GetChild(4).gameObject.SetActive(true);
			AudioSource_Royal.clip = AudioClip_SkillQ;
			AudioSource_Royal.Play();

			allowQ = false;
			lockQ = true;
			startTimeQ = Time.time;
		}
		else if (lockQ && Time.time - startTimeQ >= 5)
		{
			allowQ = true;
			lockQ = false;
		}
		else if (lockQ && Time.time - startTimeQ >= 1)
		{
			gameObject.GetComponent<Stats>().magicResist = 10;
			gameObject.GetComponent<Stats>().armor = 20;
			gameObject.transform.GetChild(4).gameObject.SetActive(false);
		}

		// Skill W
		if (Input.GetKeyDown(KeyCode.W) && allowW)
		{
			gameObject.transform.position += new Vector3(5, 0, 0);
			AudioSource_Royal.clip = AudioClip_SkillW;
			AudioSource_Royal.Play();

			allowW = false;
			lockW = true;
			startTimeW = Time.time;
		}
		else if (lockW && Time.time - startTimeW >= 10)
		{
			allowW = true;
			lockW = false;
		}

		// Skill E
		if (Input.GetKeyDown(KeyCode.E) && allowE)
		{
			gameObject.GetComponent<Stats>().health += 200;
			gameObject.GetComponent<Stats>().damage += 200;
			SpriteRenderer_Royal.color = Color.red;
			AudioSource_Royal.clip = AudioClip_SkillE;
			AudioSource_Royal.Play();

			allowE = false;
			lockE = true;
			lockE2 = true;
			startTimeE = Time.time;
		}
		else if (lockE && lockE2 && Time.time - startTimeE >= 5)
		{
			gameObject.GetComponent<Stats>().health -= 200;
			gameObject.GetComponent<Stats>().damage -= 200;
			SpriteRenderer_Royal.color = Color.white;

			lockE2 = false;
		}
		else if (lockE && Time.time - startTimeE >= 30)
		{
			allowE = true;
			lockE = false;
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
