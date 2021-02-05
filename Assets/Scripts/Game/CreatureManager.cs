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

    private Vector3 _creepSpawnPosX = new Vector3(3, 0, 0);
    private Vector3 _creepSpawnPosY = new Vector3(0, 1, 0);

    private void Awake()
    {
        BlueBase = GameObject.Find("Team Blue Base").transform;
        RedBase = GameObject.Find("Team Red Base").transform;

        // Spawn hero
        var _diffToBase = new Vector3(2, 0, 0);
        spawnedPlayerHero = Instantiate(HeroManager.playerControledHero, BlueBase.transform.position + _diffToBase, BlueBase.transform.rotation);
        spawnedEnemyHero = Instantiate(HeroManager.OpponentControledHero, RedBase.transform.position - _diffToBase, RedBase.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("SpawnBlue", 0, 10);
		InvokeRepeating("SpawnRed", 0, 10);
	}

	// To spawn creeps
	private void SpawnBlue()
    {
        Instantiate(creepBlue, BlueBase.position + _creepSpawnPosX + _creepSpawnPosY, BlueBase.rotation).AddComponent<CreepMove>().whichWay = "Up";
        Instantiate(creepBlue, BlueBase.position + _creepSpawnPosX, transform.rotation).AddComponent<CreepMove>().whichWay = "Mid";
        Instantiate(creepBlue, BlueBase.position + _creepSpawnPosX - _creepSpawnPosY, BlueBase.rotation).AddComponent<CreepMove>().whichWay = "Down";
    }

    // To spawn creeps
    private void SpawnRed()
    {
        Instantiate(creepRed, RedBase.position - _creepSpawnPosX + _creepSpawnPosY, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Up";
        Instantiate(creepRed, RedBase.position - _creepSpawnPosX, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Mid";
        Instantiate(creepRed, RedBase.position - _creepSpawnPosX - _creepSpawnPosY, RedBase.rotation).AddComponent<CreepMove>().whichWay = "Down";
    }
}
