using UnityEngine;
using System.Collections;

public class HeartBeatScript : MonoBehaviour {
	public enum HeartBeatRate
	{
		ZeroRate,
		LowestRate,
		LowRate,
		MediumRate,
		HighRate,
		HighestRate
	};
	public HeartBeatRate heartBeatRate;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("[HeartBeatScript] Triggered with speed " + heartBeatRate);

		if (heartBeatRate == HeartBeatRate.ZeroRate)
			SoundEffectHelperScript.Instance.StopHeartSound();
		else if (heartBeatRate == HeartBeatRate.LowestRate)
			SoundEffectHelperScript.Instance.PlayHeartLowestRateSound();
		else if (heartBeatRate == HeartBeatRate.LowRate)
			SoundEffectHelperScript.Instance.PlayHeartLowRateSound();
		else if (heartBeatRate == HeartBeatRate.MediumRate)
			SoundEffectHelperScript.Instance.PlayHeartMediumRateSound();
		else if (heartBeatRate == HeartBeatRate.HighRate)
			SoundEffectHelperScript.Instance.PlayHeartHighRateSound();
		else if (heartBeatRate == HeartBeatRate.HighestRate)
			SoundEffectHelperScript.Instance.PlayHeartHighestRateSound();
		else
			Debug.LogError("[HeartBeatScript] Unknown speed: " + heartBeatRate);
	}
}
