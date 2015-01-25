using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	private bool pressed = false;
	public GameObject beforeMenu,afterMenu;
	public float delay = 1.5f;
	public GameObject bus;
	public float busSpeed;

	private float timer = 0;

	void Start()
	{
		afterMenu.SetActive(false);
	}

	void Update()
	{
		if (pressed)
		{
			beforeMenu.SetActive(false);
			afterMenu.SetActive(true);
			bus.rigidbody2D.velocity = new Vector2(busSpeed,0f);

			timer = timer + Time.deltaTime;
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			if (timer >= delay)
				Application.LoadLevel("MazeTcholas");
		}
	}

	void OnGUI()
	{
		Texture startButtonTexture = (Texture)Resources.Load("barra3");
		Rect buttonRect = new Rect(Screen.width / 2 - (startButtonTexture.width / 2),
		                           (2 * Screen.height / 3) - (startButtonTexture.height / 2),
		                           startButtonTexture.width,
		                           startButtonTexture.height);

		// Draw a button to start the game
		if(GUI.Button(buttonRect, startButtonTexture))
		{
			pressed = true;
		}
	}
}
