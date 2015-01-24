using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour 
{
	private GameObject walking;

	void Start () 
	{
		walking = transform.Find("Walking").gameObject;
	}
	void Update () 
	{
		if (rigidbody2D.velocity != new Vector2(0f,0f))
		{
			walking.SetActive(true);
			renderer.enabled = false;
		}
		else
		{
			walking.SetActive(false);
			renderer.enabled = true;
		}
	}
}
