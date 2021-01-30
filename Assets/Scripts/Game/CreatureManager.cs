using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public static GameObject spawnedPlayerHero;
    public static GameObject spawnedEnemyHero;

    public GameObject creepBlue;
    public GameObject creepRed;

    private Transform BlueBase;
    private Transform RedBase;

    private Vector2 spawnPos = new Vector2(0, 2);

    private void Awake()
    {
        BlueBase = GameObject.Find("Team Blue Base").transform;
        RedBase = GameObject.Find("Team Red Base").transform;

        // Spawn hero
        spawnedPlayerHero = Instantiate(HeroManager.playerControledHero, BlueBase.transform.position, BlueBase.transform.rotation);
        spawnedEnemyHero = Instantiate(HeroManager.OpponentControledHero, RedBase.transform.position, RedBase.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("SpawnBlue", 0, 5);
		InvokeRepeating("SpawnRed", 0, 5);
	}

	// To spawn creeps
	private void SpawnBlue()
    {
        Instantiate(creepBlue, (Vector2)BlueBase.position + spawnPos, BlueBase.rotation).AddComponent<CreepMove>().whichWay = "Up";
        Instantiate(creepBlue, BlueBase.position, transform.rotation).AddComponent<CreepMove>().whichWay = "Mid";
        Instantiate(creepBlue, (Vector2)BlueBase.position - spawnPos, BlueBase.rotation).AddComponent<CreepMove>().whichWay = "Down";
    }

    // To spawn creeps
    private void SpawnRed()
    {
        Instantiate(creepRed, (Vector2)RedBase.position + spawnPos, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Up";
        Instantiate(creepRed, RedBase.position, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Mid";
        Instantiate(creepRed, (Vector2)RedBase.position - spawnPos, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Down";
    }
}
