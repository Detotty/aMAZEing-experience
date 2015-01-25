using UnityEngine;
using System.Collections;

public enum GameStates
{
	PLAYING,
	PAUSED,
	GAMEOVER,
	WIN
};

public class GameState : MonoBehaviour 
{
	public static GameState Instance;

	public float endGameTime = 7;
	private float timer = 0;

	public GameStates currentState;
	private GameStates prevState;

	public GameObject gameOver;
	public GameObject map;
	public GameObject ending;

	void Start () 
	{
		gameOver.renderer.enabled = false;
		ending.renderer.enabled = false;
	}
	
	void Update () 
	{
		if (BatteriesHelper.Instance.Power == 0)
			currentState = GameStates.GAMEOVER;

		if (prevState != GameStates.GAMEOVER && currentState == GameStates.GAMEOVER)
			GameOver();
		if (currentState == GameStates.WIN)
		{
			map.SetActive(false);
			timer = timer + Time.deltaTime;
			if (timer >= endGameTime)
			{
				ending.renderer.enabled = true;
			}
		}

		prevState = currentState;
	}
	
	void GameOver()
	{
		gameOver.renderer.enabled = true;
		map.SetActive(false);
	}
}
