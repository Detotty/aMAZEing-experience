using UnityEngine;
using System.Collections;

public class GhostScript : MonoBehaviour 
{
	public float timer = 4;
	public GameObject lantern;

	private bool disappear = false;

	void Update () 
	{
		if (lantern.collider2D.OverlapPoint(transform.position))
			disappear = true;
		
		if (disappear)
			Object.Destroy(gameObject,timer);
	}
}
