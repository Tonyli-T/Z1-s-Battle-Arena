using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecideHero : MonoBehaviour
{
    public GameObject hero;
	public GameObject knob;

    public void ChangeToMainScene()
	{
		DontDestroyOnLoad(Instantiate(hero, knob.transform.position, knob.transform.rotation));
		SceneManager.LoadScene(0);
	}
}
