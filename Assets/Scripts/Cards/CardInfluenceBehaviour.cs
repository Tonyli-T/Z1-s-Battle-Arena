using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfluenceBehaviour : MonoBehaviour
{
    public bool beingAffectedBySilance = false;
    public bool beingAffectedByArcane = false;
    public bool beingAffectedByTransform = false;
    public bool beingAffectedByPoision = false;
    public bool beingAffectedByHaste = false;

	private ObjectInfoBehaviour ObjectInfoBehaviour;

	private void Start()
	{
		ObjectInfoBehaviour = GetComponent<ObjectInfoBehaviour>();
	}

	private void Update()
	{
		// Transform the faction of a regular creep
		if (beingAffectedByTransform)
		{
			if (ObjectInfoBehaviour.faction == "Team Red")
			{
				ObjectInfoBehaviour.faction = "Team Blue";
				gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
				gameObject.GetComponent<CreepMove>().enabled = false;
			}
			else
			{
				ObjectInfoBehaviour.faction = "Team Red";
				gameObject.GetComponent<SpriteRenderer>().color = Color.red;
				gameObject.GetComponent<CreepMove>().enabled = false;
			}

			beingAffectedByTransform = false;
		}

		// Poison effects to heroes
		if (beingAffectedByPoision)
		{
			GetComponent<Move>().velocity -= 10;
			GetComponent<Stats>().health -= 15;
			beingAffectedByPoision = false;
		}

		// Haste effects to heroes
		if (beingAffectedByHaste)
		{
			GetComponent<Move>().velocity += 10;
			beingAffectedByHaste = false;
		}
	}
}
