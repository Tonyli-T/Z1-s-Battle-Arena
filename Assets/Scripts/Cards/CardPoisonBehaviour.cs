using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoisonBehaviour : MonoBehaviour
{
    private SelectionManager SelectionManager;

    // Start is called before the first frame update
    void Start()
    {
        SelectionManager = GameObject.Find("Selection Manager").GetComponent<SelectionManager>();
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (SelectionManager.beingSelected && SelectionManager.cardName == transform.name 
            && collision.GetComponent<ObjectInfoBehaviour>().type == "Hero"
            && Input.GetMouseButtonDown(0))
        {
            collision.GetComponent<CardInfluenceBehaviour>().beingAffectedByPoision = true;
            SelectionManager.beingSelected = false;
            GameObject.Destroy(gameObject);     
        }
    }
}
