using UnityEngine;
using System.Collections;

public class BatteriesScript : MonoBehaviour
{
	public int power = 3;
	public float period = 30;

	public Texture texture;
	public float scale = 0.25f;
	public float x = 0;
	public float y = 0;

	private float elapsedTime = 0;

	void UpdateBatteryPower()
	{
		--power;
		Debug.Log("Battery power: " + power);

		if (power == 0)
		{
			Debug.Log("Battery is dead");
			GameObject playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null)
				Destroy(playerObject);
			Destroy(gameObject);
		}
	}

	// Draw batteries with respect to the player position
	void OnGUI()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		if (playerObject != null)
		{
			Vector3 playerPosition = playerObject.transform.position;
			playerPosition.x += x;
			playerPosition.y -= y;
			Vector3 newPosition = Camera.main.WorldToScreenPoint(playerPosition);

			Rect position = new Rect(newPosition.x, newPosition.y, scale*Screen.width*0.25f, scale*Screen.height/3f*power);
			Rect size = new Rect(0, 0, 1.0f, 1.0f/3f*power);
			GUI.DrawTextureWithTexCoords(position, texture, size);
		}
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > period)
		{
			elapsedTime = 0;
			UpdateBatteryPower();
		}
	}
}
