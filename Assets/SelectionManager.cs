using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;
    public bool beingSelected = false;
    public string cardName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			if (beingSelected)
			{
                beingSelected = false;
            }

			Vector3 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mouseClick, Vector3.forward);

            // If it hits something...
            if (hit.collider != null && hit.transform.CompareTag("Card"))
            {
                hit.transform.GetComponent<SpriteRenderer>().material = highlightMaterial;
                beingSelected = true;
                cardName = hit.transform.name;
            }
        }
    }
}
