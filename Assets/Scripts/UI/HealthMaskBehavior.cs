using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMaskBehavior : MonoBehaviour
{
    private GameObject hero;
    public GameObject healthBar;
    private Vector3 heaalthBarPos;
    private Stats heroStats;
    private float health_Max;
    private float health_Current;

    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponentInParent<InfoBarBehaviour>().hero;
        heaalthBarPos = healthBar.transform.position + new Vector3(7.5f, 0, 0);
        heroStats = hero.GetComponent<Stats>();
        health_Max = heroStats.health;
    }

    // Update is called once per frame
    void Update()
    {
/*        health_Current = heroStats.health;
        var healthProp = health_Current / health_Max;
        
        transform.position = heaalthBarPos - new Vector3((1 - healthProp) * 7.5f, 0, 0);
*/    }
}
