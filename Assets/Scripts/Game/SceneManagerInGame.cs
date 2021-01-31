using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInGame : MonoBehaviour
{
    private HeroManager HeroManager;

    private static bool isAtPauseMenu = false;
    public static string whoWin;

    public static void ChangeToEndScene()
    {
        SceneManager.LoadScene("End Scene");
    }

    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeSceneAboutTheAuthor()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneSoloOrOnline()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeSceneChooseHero()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Redirect to the main game scene
    public void ChangeToMainScene(Object hero)
    {
        HeroManager = GameObject.Find("Hero Manager").GetComponent<HeroManager>();

        HeroManager.playerControledHero = (GameObject)hero;
        HeroManager.OpponentControledHero = HeroManager.heroes[Random.Range(0, HeroManager.heroes.Length)];

        SceneManager.LoadScene(4);
    }

    public void ChangeToMainScene()
    {
        SceneManager.LoadScene(4);
    }

    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            //Todo:: Don't intterupt the game
			if (isAtPauseMenu)
			{
                isAtPauseMenu = false;
                SceneManager.LoadScene("Game Scene");
			}
			else
			{
                isAtPauseMenu = true;
                SceneManager.LoadScene("Pause Menu");
            }
        }
	}
}
