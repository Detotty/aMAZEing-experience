using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour 
{
	public GameObject gameState;

	void Update () {}

	void OnTriggerEnter2D(Collider2D other)
	{
		gameState.GetComponent<GameState>().currentState = GameStates.WIN;
	}
}
