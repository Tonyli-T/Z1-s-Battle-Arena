using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject creepBlue;
    public GameObject creepRed;

    private Transform BlueBase;
    private Transform RedBase;

    private Vector2 spawnPos = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        BlueBase = GameObject.Find("Team Blue Base").transform;
        RedBase = GameObject.Find("Team Red Base").transform;

        // Spawn hero
        Instantiate(HeroManager.playerControledHero);

        InvokeRepeating("SpawnBlue", 1, 5);
        InvokeRepeating("SpawnRed", 1, 5);
    }

    // To spawn creeps
    private void SpawnBlue()
	{
        Instantiate(creepBlue, (Vector2)BlueBase.position + spawnPos, BlueBase.rotation).AddComponent<CreepMoveUp>();
        Instantiate(creepBlue, BlueBase.position, transform.rotation).AddComponent<CreepMoveMid>();
        Instantiate(creepBlue, (Vector2)BlueBase.position - spawnPos, BlueBase.rotation).AddComponent<CreepMoveDown>();
    }

    // To spawn creeps
    private void SpawnRed()
    {
        Instantiate(creepRed, (Vector2)RedBase.position + spawnPos, RedBase.rotation).AddComponent<CreepMoveUp>();
        Instantiate(creepRed, RedBase.position, RedBase.rotation).AddComponent<CreepMoveMid>();
        Instantiate(creepRed, (Vector2)RedBase.position - spawnPos, RedBase.rotation).AddComponent<CreepMoveDown>();
    }
}
