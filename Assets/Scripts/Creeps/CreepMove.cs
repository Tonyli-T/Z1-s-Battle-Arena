using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreepMove : MonoBehaviour
{
    public Transform goal;
    private Rigidbody2D rb2D;
    public float speed = 5;
    public float damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveTowards = goal.position - transform.position;
        rb2D.AddForce(moveTowards.normalized * speed, ForceMode2D.Force);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        rb2D.velocity = new Vector2(0, 0);

		if (collision.CompareTag("Enemy Building"))
		{
            collision.GetComponent<BaseStats>().currentHealth -= damage;
        }
    }
}
