using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneDisplayText : MonoBehaviour
{
/*	private Text endText;
*/
    // Start is called before the first frame update
    void Start()
    {
		if (SceneManagerInGame.whoWin == "Team Red")
		{
			GetComponent<Text>().text = "You win! Wanna play again ?";
		}
		else
		{
			GetComponent<Text>().text = "You lose! Wanna play again ?";
		}
    }
}
