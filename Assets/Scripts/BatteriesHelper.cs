using UnityEngine;
using System.Collections;

public class BatteriesHelper : MonoBehaviour {
	public static BatteriesHelper Instance;

	public float period = 30f;
	
	public Texture texture;
	public float scale = 0.225f;
	public float x = -5.9f;
	public float y = -0.75f;

	private float elapsedTime = 0f;

	public int startingBatteries = 3;
	public int maximumBatteries = 5;

	private int power;
	public int Power
	{
		get
		{
			return power;
		}
		private set
		{
			if (value < 0)
				power = 0;
			else if (value >= maximumBatteries)
				power = maximumBatteries;
			else
				power = value;
		}
	}

	void Awake()
	{
		if (Instance != null)
			Debug.LogError("More than one instance of BatteriesHelper!");

		Instance = this;
		Power = startingBatteries;
	}

	public void DecreasePower()
	{
		--Power;
		Debug.Log("Battery power: " + Power);
		
		if (Power == 0)
		{
			Debug.Log("Battery is dead");
			GameObject playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null)
				Destroy(playerObject);
		}
	}

	public void IncreasePower()
	{
		++Power;
		Debug.Log("Battery power: " + Power);
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
			
			Rect position = new Rect(newPosition.x, newPosition.y, scale*Screen.width*0.25f, scale*Screen.height/3f*Power);
			Rect size = new Rect(0, 0, 1.0f, 1.0f/3f*Power);
			GUI.DrawTextureWithTexCoords(position, texture, size);
		}
	}
	
	void Update()
	{
		elapsedTime += Time.deltaTime;
		
		if (elapsedTime > period)
		{
			elapsedTime = 0;
			BatteriesHelper.Instance.DecreasePower();
		}
	}
}
