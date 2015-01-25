using UnityEngine;
using System.Collections;

public enum GameStates
{
	PLAYING,
	PAUSED,
	GAMEOVER,
	WIN
};

public class GameStateHelper : MonoBehaviour 
{
	public static GameStateHelper Instance;

	public GameStates currentState;
	private GameStates prevState;

	public GameObject gameOver;

	void Start () 
	{
		if (Instance != null)
			Debug.LogError("Multiple instances of GameStateHelper");
		Instance = this;
		gameOver.renderer.enabled = false;
	}
	
	void Update () 
	{
		if (BatteriesHelper.Instance.Power == 0)
			currentState = GameStates.GAMEOVER;

		if (prevState != GameStates.GAMEOVER && currentState == GameStates.GAMEOVER)
			GameOver();

		prevState = currentState;
	}
	
	void GameOver()
	{
		gameOver.renderer.enabled = true;
		SoundEffectHelperScript.Instance.PlayGameOverSoundtrack();
	}
}
