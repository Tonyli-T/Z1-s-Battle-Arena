using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var SpriteRenderer = GetComponent<SpriteRenderer>();
		string name;

		if (transform.parent.name == "Info Bar Blue")
		{
			name = HeroManager.playerControledHero.name;
		}
		else
		{
			name = HeroManager.OpponentControledHero.name;
		}

        if (name == "Royal Knight")
		{
            SpriteRenderer.sprite = GameObject.Find("Hero Manager").GetComponent<HeroManager>().heroUISprites[0];
		}
		else if (name == "Sniper")
		{
            SpriteRenderer.sprite = GameObject.Find("Hero Manager").GetComponent<HeroManager>().heroUISprites[1];
        }
    }
}
