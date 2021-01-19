using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSilanceBehaviour : MonoBehaviour
{
    private SelectionManager SelectionManager;

    // Start is called before the first frame update
    void Start()
    {
        SelectionManager = GameObject.Find("Selection Manager").GetComponent<SelectionManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (SelectionManager.beingSelected && SelectionManager.name == transform.name)
		{
            Debug.Log(true);
		}
    }
}
