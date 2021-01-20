using UnityEngine;

public class CreepMoveDown : MonoBehaviour
{
	private GameObject enemyBase;

	private AudioSource creep_AudioSource;
	private Animator creepAnimator;
	private Rigidbody2D rb2D;

	private string selfFaction;
	public float speed = 5;
	public float damage = 5;
	public bool phase1 = true;

	// Start is called before the first frame update
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		creepAnimator = GetComponent<Animator>();
		creep_AudioSource = GetComponent<AudioSource>();
		creep_AudioSource.mute = true;

		selfFaction = GetComponent<ObjectInfoBehaviour>().faction;

		if (selfFaction == "Team Red")
		{
			enemyBase = GameObject.Find("Team Blue Base");
		}
		else if (selfFaction == "Team Blue")
		{
			enemyBase = GameObject.Find("Team Red Base");
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

		if (selfFaction == "Team Red" && collision.GetComponent<ObjectInfoBehaviour>().faction == "Team Blue")
		{
			collision.GetComponent<Stats>().health -= damage * Time.deltaTime;
			creepAnimator.SetBool("IsAttacking", true);
			creep_AudioSource.mute = false;	
		}
		else if (selfFaction == "Team Blue" && collision.GetComponent<ObjectInfoBehaviour>().faction == "Team Red")
		{
			collision.GetComponent<Stats>().health -= damage * Time.deltaTime;
			creepAnimator.SetBool("IsAttacking", true);
			creep_AudioSource.mute = false;
		}
	}

	private void OnTrigerExit2D(Collider2D collision)
	{
		creepAnimator.SetBool("IsAttacking", false);
		creep_AudioSource.mute = true;
	}
}
