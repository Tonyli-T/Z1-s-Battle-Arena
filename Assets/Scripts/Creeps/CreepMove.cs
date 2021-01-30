using UnityEngine;

public class CreepMove : MonoBehaviour
{
	private GameObject enemyBase;

	private AudioSource creep_AudioSource;
	private Rigidbody2D rb2D;

	public float speed = 2;
	public float damage = 5;
	public bool phase1 = true;

	private string selfFaction;
	public string whichWay;

	// Start is called before the first frame update
	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
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
		Vector2 moveTowards;

		if (whichWay == "Mid")
		{
			moveTowards = enemyBase.transform.position - transform.position;
			rb2D.AddForce(moveTowards.normalized * speed, ForceMode2D.Force);
		}
		else
		{
			if (whichWay == "Down")
			{
				moveTowards = GameObject.Find("Traction Point Down").transform.position - transform.position;
			}
			else
			{
				moveTowards = GameObject.Find("Traction Point Up").transform.position - transform.position;
			}

			if (phase1)
			{
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

		//TODO. Maybe stop creeps when they approach the base
	}
}
