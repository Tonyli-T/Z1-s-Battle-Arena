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
		
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (SelectionManager.beingSelected && SelectionManager.cardName == transform.name && SelectionManager.allowCasting)
        {
            collision.GetComponent<CardInfluenceBehaviour>().beingAffectedBySilance = true;
            SelectionManager.allowCasting = false;
            GameObject.Destroy(gameObject);
        }
    }
}
