using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecideHero : MonoBehaviour
{
    public GameObject heroType;
	public GameObject knob;

	public GameObject currentHero;

	public void ChangeToMainScene()
	{
		currentHero = Instantiate(heroType, knob.transform.position, knob.transform.rotation);
		DontDestroyOnLoad(currentHero);
		SceneManager.LoadScene(0);
	}
}
