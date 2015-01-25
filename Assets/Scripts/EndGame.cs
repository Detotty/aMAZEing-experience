using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour 
{
	public float endGameTime = 6;
	public float creditsTime = 2;
	private float timer = 0;

	public GameObject endingObject;

	void Start()
	{
		endingObject.renderer.enabled = false;
	}

	void Update () 
	{
		if (GameStateHelper.Instance.currentState == GameStates.WIN)
		{
			timer = timer + Time.deltaTime;
			if (timer >= endGameTime)
			{
				endingObject.renderer.enabled = true;
			}
			if (timer >= endGameTime + creditsTime)
				Application.LoadLevel("Credits");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameStateHelper.Instance.currentState = GameStates.WIN;
	}
}
