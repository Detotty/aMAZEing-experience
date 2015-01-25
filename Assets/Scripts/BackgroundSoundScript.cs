using UnityEngine;
using System.Collections;

public class BackgroundSoundScript : MonoBehaviour
{

	public AudioClip crowSound;
	public float timeInterval = 15;
	public float audioProbability = 0.1f;

	private float elapsedTime = 0;

	void MakeSound()
	{
		float random = Random.Range(0f, 1f);

		Debug.Log("[BackgroundSoundScript] MakeSound: Random number: " + random);

		if (random < audioProbability)
			AudioSource.PlayClipAtPoint(crowSound, transform.position);
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > timeInterval)
		{
			MakeSound();
			elapsedTime = 0;
		}
	}
}
