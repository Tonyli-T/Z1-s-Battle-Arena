using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
	public GameObject regenerationProp;
	public GameObject[] cards;
	public Transform cardSpawnPos;
	public Transform cardDestroyPos;

	public float regenerateFrequency = 5;
	public float cardsFrequency = 10;

	public float spawnRangeLeft = -10;
	public float spawnRangeRight = 10;

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("GenerateRegenerationProp", 0, regenerateFrequency);
		InvokeRepeating("GenerateCards", 0, cardsFrequency);
	}

	// Helper method used by GenerateRegenerationProp()
	private (float x, float y) GenerateProps()
	{
		// Randomly generate a prop around traction points
		var randomNum = Random.Range(spawnRangeLeft, spawnRangeRight);
		var x = GameObject.Find("Traction Point Up").transform.position.x + randomNum;
		var y = GameObject.Find("Traction Point Up").transform.position.y + randomNum;
		return (x, y);
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
		var card = Instantiate(cards[Random.Range(0, cards.Length)], cardSpawnPos.position, cardSpawnPos.rotation);
		StartCoroutine(MoveCards(card));
	}

	IEnumerator MoveCards(GameObject card)
	{
		while (!Mathf.Approximately(card.transform.position.x, cardDestroyPos.transform.position.x))
		{
			card.transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
			yield return null; 
		}

		GameObject.Destroy(card);
	}
}
