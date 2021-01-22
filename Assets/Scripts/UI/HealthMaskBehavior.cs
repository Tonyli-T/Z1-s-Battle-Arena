using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaskBehavior : MonoBehaviour
{
    public GameObject blood;

    private Stats heroStats;

    private Vector3 startPos;
    private float health_Max;
    private float health_Current;

    // Start is called before the first frame update
    void Start()
    { 
        startPos = transform.position;
        heroStats = SpawnManager.spawnedPlayerHero.GetComponent<Stats>();
        health_Max = heroStats.health;
    }
    
	// Update is called once per frame
	void Update()
    {
		health_Current = heroStats.health;
		var healthProp = health_Current / health_Max;

		if (healthProp <= 0.3)
		{
            //Debug.Log(healthProp % 2);
            if ((healthProp * 10) % 2 >= 1)
			{
                blood.GetComponent<SpriteRenderer>().color = Color.white;
                
			}
			else
			{
                blood.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

		transform.position = startPos + new Vector3((1 - healthProp) * 6.5f, 0, 0);
	}
}
