using UnityEngine;
using System.Collections;

public class BatteryMouseScript : MonoBehaviour 
{
	public GameObject lantern;
	public Vector2 speed = new Vector2(0f,5f);


	void Update()
	{
		if (lantern.collider2D.OverlapPoint(transform.position))
			rigidbody2D.velocity = speed;
	}
}
