using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
	public AudioClip destroySound_AudioClip;
	private ParticleSystem ParticleSystem;
	private AudioSource AudioSource;
	public float maxHealth;
    public float currentHealth;

	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();
		ParticleSystem = GetComponent<ParticleSystem>();
	}

	private void Update()
	{
		if (currentHealth <= 0)
		{
			AudioSource.clip = destroySound_AudioClip;
			AudioSource.Play();
			// TODO... ParticleSystem
			GameObject.Destroy(gameObject);
		}
	}
}
 