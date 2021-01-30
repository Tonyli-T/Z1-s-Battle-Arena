using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("Hero Manager").GetComponent<HeroManager>().heroUISprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
