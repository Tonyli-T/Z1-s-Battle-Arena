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

	private void Update()
	{
		// Transform the faction of a regular creep
		if (beingAffectedByTransform)
		{
			if (GetComponent<ObjectInfoBehaviour>().faction == "Team Red")
			{
				GetComponent<ObjectInfoBehaviour>().faction = "Team Blue";
			}
			else
			{
				GetComponent<ObjectInfoBehaviour>().faction = "Team Red";
			}

			beingAffectedByTransform = false;
		}
	}
}
