using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public static GameObject testObject;
    public GameObject testObjectType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Button b;
        //Sprite.
    }

	private void OnMouseDown()
	{
        testObject = testObjectType;
        DontDestroyOnLoad(Instantiate(testObject));
        SceneManager.LoadScene("Test 2");
    }

	/*private void OnMouseOver()
	{
        
	}*/
}
