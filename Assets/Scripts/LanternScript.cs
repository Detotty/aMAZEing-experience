using UnityEngine;
using System.Collections;
public class LanternScript : MonoBehaviour
{
	public GameObject player;
	public float blinkingPeriod = 1.5f;
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
			if (BatteriesHelper.Instance.Power == 0)
				failure.renderer.enabled = true;
		}
	}
	void Blink()
	{
		timer = timer + Time.deltaTime;
		if (!failure.renderer.enabled)
		{
			if (timer >= blinkingPeriod)
			{
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
}