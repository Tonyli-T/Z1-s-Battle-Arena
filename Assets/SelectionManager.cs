using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;
    public bool beingSelected = false;
    public bool allowCasting = false;
    public string cardName;
    public RaycastHit2D card_Hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Drag cards and use ability
		if (beingSelected)
		{
            card_Hit.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Input.GetMouseButtonDown(0))
			{
                allowCasting = true;
                beingSelected = false;
            }
        }

        // Select a card, and use it on map
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseClick, Vector3.forward);

            // If it hits a card
            if (hit.collider != null && hit.transform.CompareTag("Card"))
            {
                hit.transform.GetComponent<SpriteRenderer>().material = highlightMaterial;
                beingSelected = true;
                cardName = hit.transform.name;
                card_Hit = hit;
            }
        }

        // Deselect a card
		if (Input.GetMouseButtonDown(1))
		{
            
			if (beingSelected)
			{
                beingSelected = false;
			}
		}
    }
}
