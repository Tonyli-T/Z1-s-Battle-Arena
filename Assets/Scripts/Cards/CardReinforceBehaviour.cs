using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReinforceBehaviour : BaseCardBehaviour
{
    public GameObject archer;
    private SelectionManager SelectionManager;

    // Start is called before the first frame update
    void Start()
    {
        SelectionManager = GameObject.Find("Selection Manager").GetComponent<SelectionManager>();
        StartCoroutine(MoveCards(gameObject, GameObject.Find("Card Destroy Pos").transform));
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(SelectionManager.beingSelected);
        if (SelectionManager.beingSelected && SelectionManager.cardName == transform.name && Input.GetMouseButtonDown(0))
        {
            Instantiate(archer, transform.position, transform.rotation);
            SelectionManager.beingSelected = false;
            GameObject.Destroy(gameObject);
        }
    }
}
