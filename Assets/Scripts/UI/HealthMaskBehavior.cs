using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaskBehavior : MonoBehaviour
{
    public GameObject hero;
    public GameObject healthBar;
    private Vector3 heaalthBarPos;
    private Stats heroStats;
    private float health_Max;
    private float health_Current;

    // Start is called before the first frame update
    void Start()
    {
        heaalthBarPos = healthBar.transform.position;
        heroStats = hero.GetComponent<Stats>();
        health_Max = heroStats.health;
    }

    // Update is called once per frame
    void Update()
    {
        health_Current = heroStats.health;
        var healthProp = health_Current / health_Max;
        Debug.Log(transform.position);
        transform.position = heaalthBarPos + new Vector3(healthProp, 0, 0);
    }
}
