using UnityEngine;
using System.Collections;

public class SoundEffectHelperScript : MonoBehaviour
{
	public static SoundEffectHelperScript Instance = null;

	public float lanternVolume = 1f;
	public float screamVolume = 1f;
	public float collectVolume = 0.75f;

	public AudioClip lanternSound;
	public AudioClip screamSound;
	public AudioClip collectSound;

	public AudioClip heartLowestRate;
	public AudioClip heartLowRate;
	public AudioClip heartMediumRate;
	public AudioClip heartHighRate;
	public AudioClip heartHighestRate;

	public AudioClip soundtrack;
	public AudioClip gameOverSoundtrack;

	private AudioSource audioSource;
	private AudioSource heartAudioSource;

	void Start()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;

		audioSource = gameObject.AddComponent<AudioSource>();
		heartAudioSource = gameObject.AddComponent<AudioSource>();

		Debug.Log("[SoundEffectHelperScript] Audio source: " + audioSource);
		PlayGameSoundtrack();
	}

	private void MakeSound(AudioClip originalClip, float volume)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position, volume);
	}

	public void PlaySoundtrack(AudioClip soundtrack, bool loop)
	{
		if (audioSource != null)
		{
			Debug.Log("[SoundEffectHelperScript] Play soundtrack " + soundtrack);
			if (audioSource.isPlaying)
				audioSource.Stop();

			audioSource.loop = loop;
			audioSource.clip = soundtrack;
			audioSource.volume = 1;
			audioSource.Play();
		}
		else
		{
			Debug.Log("[SoundEffectHelperScript] No audio source");
		}
	}

	public void MakeLanternSound()
	{
		MakeSound(lanternSound, lanternVolume);
	}

	public void MakeScreamSound()
	{
		MakeSound(screamSound, screamVolume);
	}

	public void PlayGameSoundtrack()
	{
		Debug.Log("[SoundEffectHelperScript] Play game soundtrack");
		PlaySoundtrack(soundtrack, true);
	}

	public void PlayGameOverSoundtrack()
	{
		PlaySoundtrack(gameOverSoundtrack, false);
	}

	public void MakeCollectSound()
	{
		MakeSound(collectSound, collectVolume);
	}

	public void PlayHeartSoundtrack(AudioClip soundtrack)
	{
		if (heartAudioSource != null)
		{
			if (heartAudioSource.isPlaying)
				heartAudioSource.Stop();
			
			heartAudioSource.loop = true;
			heartAudioSource.clip = soundtrack;
			heartAudioSource.volume = 0.40f;
			heartAudioSource.Play();
		}
	}
	
	public void PlayHeartLowestRateSound()
	{
		PlayHeartSoundtrack(heartLowestRate);
	}

	public void PlayHeartLowRateSound()
	{
		PlayHeartSoundtrack(heartLowRate);
	}

	public void PlayHeartMediumRateSound()
	{
		PlayHeartSoundtrack(heartMediumRate);
	}

	public void PlayHeartHighRateSound()
	{
		PlayHeartSoundtrack(heartHighRate);
	}

	public void PlayHeartHighestRateSound()
	{
		PlayHeartSoundtrack(heartHighestRate);
	}

	public void StopHeartSound()
	{
		if (heartAudioSource != null && heartAudioSource.isPlaying)
			heartAudioSource.Stop();
	}
}