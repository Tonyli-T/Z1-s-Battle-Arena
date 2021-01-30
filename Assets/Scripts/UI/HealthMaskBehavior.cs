using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaskBehavior : MonoBehaviour
{
    public GameObject blood;

    private Stats Stats;

	private string whatKind;
	private string heroFaction;

	private Vector3 startPos;
    private float health_Max;
    private float health_Current;

	// Start is called before the first frame update
	void Start()
    {
		whatKind = GetComponent<ObjectInfoBehaviour>().type;
		heroFaction = GetComponent<ObjectInfoBehaviour>().faction;

		if (whatKind == "HeroHealthMask")
		{
			if (heroFaction == "Blue")
			{
				Stats = CreatureManager.spawnedPlayerHero.GetComponent<Stats>();
			}
			else if (heroFaction == "Red")
			{
				Stats = CreatureManager.spawnedEnemyHero.GetComponent<Stats>();
			}
		}
		else if (whatKind == "BaseHealthMask")
		{
			Stats = GetComponentInParent<Stats>();
		}

		startPos = transform.position;

        health_Max = Stats.health;
	}
    
	// Update is called once per frame
	void Update()
	{
		HealthMaskChange();
	}

	private void HealthMaskChange()
	{
		health_Current = Stats.health;
		var healthProp = health_Current / health_Max;

		// Blink effect
		if (healthProp <= 0.3)
		{
			if ((healthProp * 10) % 2 >= 1)
			{
				blood.GetComponent<SpriteRenderer>().color = Color.white;
			}
			else
			{
				blood.GetComponent<SpriteRenderer>().color = Color.red;
			}
		}

		if (whatKind == "BaseHealthMask")
		{
			transform.position = startPos - new Vector3(0, (1 - healthProp) * 22, 0);
		}
		else if (whatKind == "HeroHealthMask")
		{
			if (heroFaction == "Red")
			{
				transform.position = startPos - new Vector3((1 - healthProp) * 6.5f, 0, 0);
			}
			else if (heroFaction == "Blue")
			{
				transform.position = startPos + new Vector3((1 - healthProp) * 6.5f, 0, 0);
			}
		}		
	}
}
