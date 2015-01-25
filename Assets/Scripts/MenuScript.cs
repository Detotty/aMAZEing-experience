using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	bool pressed = false;

	void Update()
	{
		if (pressed)
		{
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
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
