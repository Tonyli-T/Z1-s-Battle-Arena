using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regeneration_Prop : MonoBehaviour
{
    public float healNum = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<ObjectInfoBehaviour>().type == "Hero")
		{
			collision.GetComponent<Stats>().health += healNum;
			GameObject.Destroy(gameObject);
		}
	}
}
