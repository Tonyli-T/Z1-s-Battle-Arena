using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    //public string tag;
    public float hitBackProbability = 0;
    public Vector2 hitBackDistance = new Vector2(-5, 0);
    public float damage;

    public AudioClip hitSound;
    private AudioSource SoundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
            if (Random.value <= hitBackProbability)
            {
                SoundPlayer.clip = hitSound;
                SoundPlayer.Play();
                collision.attachedRigidbody.position += hitBackDistance;
                collision.GetComponent<Stats>().health -= damage;
            }
            else
            {
                collision.GetComponent<Stats>().health -= damage;
            }
        }
    }
}
