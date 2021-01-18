using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBarBehaviour : MonoBehaviour
{
    public DecideHero DecideHero;
    public GameObject hero;

    // Start is called before the first frame update
    void Start()
    {
        hero = DecideHero.currentHero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
