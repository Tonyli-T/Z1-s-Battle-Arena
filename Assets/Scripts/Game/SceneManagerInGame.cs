using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInGame : MonoBehaviour
{
    private static bool isAtPauseMenu = false;

    public void ChangeSceneMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneAboutTheAuthor()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeSceneSoloOrOnline()
    {
        SceneManager.LoadScene(3);
    }

    public void ChangeSceneChooseHero()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Redirect to the main game scene
    public void ChangeToMainScene(Object hero)
    {
        HeroManager.playerControledHero = (GameObject)hero;

        SceneManager.LoadScene(0);
    }

    public void ChangeToMainScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            //Debug.Log(isAtPauseMenu);
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
