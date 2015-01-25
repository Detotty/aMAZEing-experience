using UnityEngine;
using System.Collections;
public class LanternScript : MonoBehaviour
{
	public GameObject player;
	public float blinkingPeriodSlow = 1.5f;
	public float blinkingPeriodFast = 0.5f;
	public float blinkingDuration = 0.2f;
	private GameObject failure;
	private float timer = 0;
	public AudioClip blinkSound;
	
	void Start()
	{
		failure = transform.Find("Failure").gameObject;
		failure.renderer.enabled = false;
	}
	
	void Update()
	{
		if ((player != null) && (GameStateHelper.Instance.currentState == GameStates.PLAYING))
		{
			transform.eulerAngles = player.transform.eulerAngles;
			transform.position = player.transform.position;
			if (BatteriesHelper.Instance.Power == 1 || BatteriesHelper.Instance.Power == 2)
				Blink();
			else if (BatteriesHelper.Instance.Power == 0)
				failure.renderer.enabled = true;
		}
	}
	
	void Blink()
	{
		float blinkingPeriod = CalculatePeriod();

		timer = timer + Time.deltaTime;
		if (!failure.renderer.enabled)
		{
			if (timer >= blinkingPeriod)
			{
				Debug.Log("[LanterScript] Blink: Blinking period " + blinkingPeriod);
				failure.renderer.enabled = true;
				timer = 0;
				SoundEffectHelperScript.Instance.MakeLanternSound();
			}
		}
		else
		{
			if (timer >= blinkingDuration)
			{
				failure.renderer.enabled = false;
				timer = 0;
			}
		}
	}

		float CalculatePeriod()
		{
			if (BatteriesHelper.Instance.Power == 2)
			{
				if (BatteriesHelper.Instance.ElapsedTime < BatteriesHelper.Instance.period/2)
					return 2*blinkingPeriodSlow;
				else
					return blinkingPeriodSlow;
			}
			else
			{
				if (BatteriesHelper.Instance.ElapsedTime < BatteriesHelper.Instance.period/2)
					return blinkingPeriodFast;
				else
					return blinkingPeriodFast/2;
			}
		}
}