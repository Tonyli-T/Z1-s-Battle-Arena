using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReinforceBehaviour : MonoBehaviour
{
    public GameObject archer;
    private SelectionManager SelectionManager;

    // Start is called before the first frame update
    void Start()
    {
        SelectionManager = GameObject.Find("Selection Manager").GetComponent<SelectionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectionManager.beingSelected && SelectionManager.cardName == transform.name)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(archer, transform.position, transform.rotation);
                SelectionManager.beingSelected = false;
                GameObject.Destroy(gameObject);
            }
        }
    }
}
