using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject creepUp;
    public GameObject creepMid;
    public GameObject creepDown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 5);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To spawn creeps
    private void Spawn()
	{
		if (gameObject.CompareTag("太阳圣殿"))
		{
            Instantiate(creepMid, transform.position + new Vector3(3, 0, 0), transform.rotation);
        }
        else if (gameObject.CompareTag("奥姆真理"))
        {
            Instantiate(creepMid, transform.position - new Vector3(3, 0, 0), transform.rotation);
        }

        Instantiate(creepUp, transform.position + new Vector3(0, 3, 0), transform.rotation);
        Instantiate(creepDown, transform.position - new Vector3(0, 3, 0), transform.rotation);
    }
}
