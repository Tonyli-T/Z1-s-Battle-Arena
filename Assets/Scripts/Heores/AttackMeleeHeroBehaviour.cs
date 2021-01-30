using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeHeroBehaviour : MonoBehaviour
{
    private AudioSource AudioSource;
    private Animator Animator;

    public float attackSpeed = 1;
    private float startAttackingTime;
    private bool lockAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (lockAttack)
		{
			var selfFaction = GetComponent<ObjectInfoBehaviour>().faction;
			var enemyObjectInfo = collision.gameObject.GetComponent<ObjectInfoBehaviour>();
			var enemyStats = collision.gameObject.GetComponent<Stats>();

			if (enemyObjectInfo != null && enemyObjectInfo.faction != selfFaction
				&& enemyStats != null)
			{
				var damage = GetComponent<Stats>().damage;
				enemyStats.health -= damage * Time.deltaTime;
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && !lockAttack)
		{
			AudioSource.Play();
			Animator.SetBool("IsAttacking", true);
			startAttackingTime = Time.time;
			lockAttack = true;
			
		}
		else if (lockAttack && Time.time - startAttackingTime >= attackSpeed)
		{
			lockAttack = false;
			Animator.SetBool("IsAttacking", false);
		}
	}
}
