using UnityEngine;
using System.Collections;

public class BatteriesScript : MonoBehaviour
{
	public int energy = 10;
	public float period = 30;

	private float elapsedTime = 0;

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > period)
		{
			--energy;
			elapsedTime = 0;
			Debug.Log("Battery charge: " + energy);
		}

		if (energy == 0)
		{
			Debug.Log("Battery is dead");
			Destroy(gameObject);
		}
	}
}
