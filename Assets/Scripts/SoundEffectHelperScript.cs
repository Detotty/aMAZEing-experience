using UnityEngine;
using System.Collections;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectHelperScript : MonoBehaviour
{
	void Start() {}
	void Update() {}
	
	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundEffectHelperScript Instance = null;
	
	public AudioClip eletricSound;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}
	
	public void MakeEletricSound()
	{
		MakeSound(eletricSound, false);
	}
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip, bool loop)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}