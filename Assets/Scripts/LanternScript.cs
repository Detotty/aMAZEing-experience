using UnityEngine;
using System.Collections;
public class LanternScript : MonoBehaviour
{
	public GameObject player;
	public float blinkingPeriodSlow = 1.5f;
	public float blinkingPeriodFast = 0.5f;
	public float blinkingDuration = 0.2f;
	private GameObject failure;
	public GameObject scripts;
	private float timer = 0;

	void Start()
	{
		failure = transform.Find("Failure").gameObject;
		failure.renderer.enabled = false;
	}
	void Update()
	{
		if (player != null)
		{
			transform.eulerAngles = player.transform.eulerAngles;
			transform.position = player.transform.position;

			if (BatteriesHelper.Instance.Power == 1)
				Blink();
			else if (BatteriesHelper.Instance.Power == 0)
				failure.renderer.enabled = true;
		}
	}

	void Blink()
	{
		//if the time is running out, blink faster
		float blinkingPeriod = CalculatePeriod();

		timer = timer + Time.deltaTime;
		if (!failure.renderer.enabled)
		{
			if (timer >= blinkingPeriod)
			{
				SoundEffectHelperScript.Instance.MakeEletricSound();
				failure.renderer.enabled = true;
				timer = 0;
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
		if (BatteriesHelper.Instance.ElapsedTime < 2*BatteriesHelper.Instance.period/3)
			return blinkingPeriodSlow;
		else if (BatteriesHelper.Instance.ElapsedTime < 11*BatteriesHelper.Instance.period/12)
			return blinkingPeriodFast;
		else
			return blinkingPeriodFast/2;
	}
}