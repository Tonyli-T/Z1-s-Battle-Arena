using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	public float health;
	public float damage;
	public float magicResist;
	public float armor;

	private void Update()
	{
		if (health <= 0)
		{
			if (gameObject.name == "Team Blue Base")
			{
				SceneManagerInGame.whoWin = "Team Blue";
				SceneManagerInGame.ChangeToEndScene();
			}
			else if (gameObject.name == "Team Red Base")
			{
				SceneManagerInGame.whoWin = "Team Red";
				SceneManagerInGame.ChangeToEndScene();
			}

			Destroy(gameObject);
		}
	}
}
