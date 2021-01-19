using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBarBehaviour : MonoBehaviour
{
    private SpriteRenderer avatar_SpriteRenderer;
    public GameObject hero;

    // Start is called before the first frame update
    void Start()
    {
        hero = HeroManager.currentHero;
        avatar_SpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        avatar_SpriteRenderer.sprite = HeroManager.heroSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
