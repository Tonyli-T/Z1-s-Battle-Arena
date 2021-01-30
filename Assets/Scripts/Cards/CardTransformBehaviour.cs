using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTransformBehaviour : BaseCardBehaviour
{
    private SelectionManager SelectionManager;
    public string team = "Team Red";

    // Start is called before the first frame update
    void Start()
    {
        SelectionManager = GameObject.Find("Selection Manager").GetComponent<SelectionManager>();
        StartCoroutine(MoveCards(gameObject, GameObject.Find("Card Destroy Pos").transform));
    }

    private void OnTriggerStay2D(Collider2D collision)
	{
        if (SelectionManager.beingSelected && SelectionManager.cardName == transform.name
            && collision.GetComponent<ObjectInfoBehaviour>().type == "Creep" 
            && collision.GetComponent<ObjectInfoBehaviour>().faction == "Team Red"
            && Input.GetMouseButtonDown(0))
        {
            collision.GetComponent<CardInfluenceBehaviour>().beingAffectedByTransform = true;
            SelectionManager.beingSelected = false;
            GameObject.Destroy(gameObject);
        }
    }
}
