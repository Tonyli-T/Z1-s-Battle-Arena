using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerInGame : MonoBehaviour
{
    private HeroManager HeroManager;

    //private static bool isAtPauseMenu = false;
    public static bool allowPauseMenu = false;

    public static string whoWin;

    public static void ChangeToEndScene()
    {
        allowPauseMenu = false;
        SceneManager.LoadScene("End Scene");
    }

    public void ChangeSceneMenu()
    {
        allowPauseMenu = false;
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
        allowPauseMenu = false;
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
        allowPauseMenu = true;

        SceneManager.LoadScene(4);
    }

    public void ChangeToMainScene()
    {
        allowPauseMenu = true;

        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Pause Menu"));
    }

    public void JumpToWechat()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    public void JumpToInstagram()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    private void Update()
	{
		if (allowPauseMenu)
		{
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                //Todo:: time scale
                allowPauseMenu = false;
                SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);    
            }
        }
    }
}
