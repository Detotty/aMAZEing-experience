using UnityEngine;
using System.Collections;

public class LivingBushScript : MonoBehaviour 
{
	public float delay = 10;
	public float duration = 1;
	private float timer = 0;

	void Update () 
	{
		transform.renderer.enabled = true;
	
		timer = timer + Time.deltaTime;
		if (timer >= delay)
		{
			if (timer > delay + duration)
				timer = 0;
			transform.renderer.enabled = false;
		}
	}
}
