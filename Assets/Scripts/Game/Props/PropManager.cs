using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
	public GameObject regenerationProp;
	public GameObject[] cards;
	public Transform cardSpawnPos;
	public Transform cardDestroyPos;

	public float regenerateFrequency = 30;
	public float cardsFrequency = 10;
	//public Coroutine c;

	private float spawnRangeLeft;
	private float spawnRangeRight;
	private float spawnRangeUp;
	private float spawnRangeDown;

	// Start is called before the first frame update
	void Start()
	{
		spawnRangeLeft = GameObject.Find("Left up regenerate spawn pos").transform.position.x;
		spawnRangeRight = GameObject.Find("Right down regenerate spawn pos").transform.position.x;
		spawnRangeUp = GameObject.Find("Left up regenerate spawn pos").transform.position.y;
		spawnRangeDown = GameObject.Find("Right down regenerate spawn pos").transform.position.y;

		InvokeRepeating("GenerateRegenerationProp", 0, regenerateFrequency);
		InvokeRepeating("GenerateCards", 0, cardsFrequency);
	}

	// Helper method used by GenerateRegenerationProp()
	private (float x, float y) GenerateProps()
	{
		// Randomly generate a prop around traction points
		var randomNumX = Random.Range(spawnRangeLeft, spawnRangeRight);
		var randomNumY = Random.Range(spawnRangeDown, spawnRangeUp);

		return (randomNumX, randomNumY);
	}

	// Generate prop around the map
	private void GenerateRegenerationProp()
	{
		var (x, y) = GenerateProps();
		Instantiate(regenerationProp, new Vector3(x , y, 0), Quaternion.Euler(0, 0, 0));
	}

	// Generate Card on the wheel
	private void GenerateCards()
	{
		Instantiate(cards[Random.Range(0, cards.Length)], cardSpawnPos.position, cardSpawnPos.rotation);
	}
}
