using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject creep;
    private Vector2 spawnPos = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 5);       
    }

    // To spawn creeps
    private void Spawn()
	{
        Instantiate(creep, (Vector2)transform.position + spawnPos, transform.rotation).AddComponent<CreepMoveUp>();
        Instantiate(creep, transform.position, transform.rotation).AddComponent<CreepMoveMid>();
        Instantiate(creep, (Vector2)transform.position - spawnPos, transform.rotation).AddComponent<CreepMoveDown>();
    }
}
