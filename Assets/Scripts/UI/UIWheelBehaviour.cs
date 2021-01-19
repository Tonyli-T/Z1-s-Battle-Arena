using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWheelBehaviour : MonoBehaviour
{
    private float startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (1 * Time.deltaTime, 0, 0); 

		if (transform.position.x - startPos >= 5)
		{
            transform.position = new Vector2(startPos, transform.position.y);
		}
    }
}
