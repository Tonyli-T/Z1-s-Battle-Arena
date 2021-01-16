using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneMain()
    {
        SceneManager.LoadScene(0);
        //Instantiate();
    }

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
}
