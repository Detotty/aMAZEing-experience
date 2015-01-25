using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour 
{
	private GameObject walking, plotTwist;

	public float endGameTime = 3.5f;
	private float endGameTimer = 0;

	void Start()
	{
		walking = transform.Find("Walking").gameObject;
		plotTwist = transform.Find("PlotTwist").gameObject;
		walking.SetActive(false);
		plotTwist.SetActive(false);
	}

	void Update()
	{
		if (GameStateHelper.Instance.currentState == GameStates.WIN)
		{
			walking.SetActive(false);
			renderer.enabled = true;
			endGameTimer = endGameTimer + Time.deltaTime;
			if (endGameTimer >= endGameTime)
			{
				plotTwist.SetActive(true);
				renderer.enabled = false;
			}
		}
		else if (rigidbody2D.velocity != new Vector2(0f,0f))
		{
			walking.SetActive(true);
			plotTwist.SetActive(false);
			renderer.enabled = false;
		}
		else
		{
			walking.SetActive(false);
			plotTwist.SetActive(false);
			renderer.enabled = true;
		}
	}
}
