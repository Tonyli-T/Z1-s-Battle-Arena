using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject creep;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5, 5);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // To spawn creeps
    private void Spawn()
	{
		Instantiate(creep, transform.position + new Vector3(3, 0, 0), transform.rotation);
        Instantiate(creep, transform.position + new Vector3(0, 3, 0), transform.rotation);
        Instantiate(creep, transform.position - new Vector3(0, 3, 0), transform.rotation);
    }
}
