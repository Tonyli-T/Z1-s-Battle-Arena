using UnityEngine;

public class CreepMoveDown : MonoBehaviour
{
	private GameObject enemyBase;
	private Animator creepAnimator;
	private Rigidbody2D rb2D;
	public float speed = 5;
	public float damage = 5;
	public bool phase1 = true;

	// Start is called before the first frame update
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		creepAnimator = GetComponent<Animator>();

		if (gameObject.CompareTag("太阳圣殿"))
		{
			enemyBase = GameObject.Find("奥姆真理");
		}
		else if (gameObject.CompareTag("奥姆真理"))
		{
			enemyBase = GameObject.Find("太阳圣殿");
		}
	}

	// Update is called once per frame
	void Update()
	{
		MoveDown();
	}

	// Used to move up road
	public void MoveDown()
	{
		Vector2 moveTowards;

		if (phase1)
		{
			moveTowards = GameObject.Find("Traction Point Down").transform.position - transform.position;
			rb2D.AddForce(moveTowards.normalized * speed, ForceMode2D.Force);
			
			if (moveTowards.magnitude <= 0.1)
			{
				phase1 = false;
				rb2D.velocity = new Vector2(0, 0);
			}
		}
		else
		{
			moveTowards = enemyBase.transform.position - transform.position;
			rb2D.AddForce(moveTowards.normalized * speed, ForceMode2D.Force);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		rb2D.velocity = new Vector2(0, 0);

		if (gameObject.CompareTag("太阳圣殿"))
		{
			if (collision.CompareTag("奥姆真理"))
			{
				collision.GetComponent<BaseStats>().currentHealth -= damage * Time.deltaTime;
				creepAnimator.SetBool("IsAttacking", true);
			}
		}
		else if (gameObject.CompareTag("奥姆真理"))
		{
			if (collision.CompareTag("太阳圣殿"))
			{
				collision.GetComponent<BaseStats>().currentHealth -= damage * Time.deltaTime;
				creepAnimator.SetBool("IsAttacking", true);
			}
		}
	}

	private void OnTrigerExit2D(Collider2D collision)
	{
		creepAnimator.SetBool("IsAttacking", false);
	}
}
