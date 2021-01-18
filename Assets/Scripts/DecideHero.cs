using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecideHero : MonoBehaviour
{
    public GameObject heroType;
	public Sprite spriteType;
	public GameObject knob;

	public static GameObject currentHero;
	public static Sprite heroSprite;

	public void ChangeToMainScene()
	{
		currentHero = Instantiate(heroType, knob.transform.position, knob.transform.rotation);
		heroSprite = spriteType;

		DontDestroyOnLoad(currentHero);
		SceneManager.LoadScene(0);
	}
}
