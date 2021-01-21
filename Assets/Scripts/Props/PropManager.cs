using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
	public GameObject regenerationProp;
	public float regenerateFrequency = 5;
	public float spawnRangeLeft = -10;
	public float spawnRangeRight = 10;

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("GenerateRegenerationProp", 0, regenerateFrequency);
	}

	private (float x, float y) GenerateProps()
	{
		// Randomly generate a prop around traction points
		var randomNum = Random.Range(spawnRangeLeft, spawnRangeRight);
		var x = GameObject.Find("Traction Point Up").transform.position.x + randomNum;
		var y = GameObject.Find("Traction Point Up").transform.position.y + randomNum;
		return (x, y);
	}

	private void GenerateRegenerationProp()
	{
		var (x, y) = GenerateProps();
		Instantiate(regenerationProp, new Vector3(x , y, 0), Quaternion.Euler(0, 0, 0));
	}
}
