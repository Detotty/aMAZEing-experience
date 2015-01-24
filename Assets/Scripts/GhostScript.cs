using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour 
{
	public float timer = 2;

	private bool disappear = false;

	void Update () 
	{
		if (disappear)
		{
			timer = timer - Time.deltaTime;
		}
		if (timer <= 0)
			renderer.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<LanternScript>() != null)
		{
			disappear = true;
		}
	}
}
