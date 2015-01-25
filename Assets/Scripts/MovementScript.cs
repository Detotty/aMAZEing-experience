using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
	// Movement variables
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(1, 0);
	private Vector2 movement;

	public GameObject gameState;
	private Vector2 endPos;

	// Get input from keyboard
	Vector2 GetInput()
	{
		float input_x = Input.GetAxis("Horizontal");
		float input_y = Input.GetAxis("Vertical");
		Vector2 input = new Vector2(input_x, input_y);
		
		return input;
	}
	
	// Calculate movement vector based on speed and input keys
	void CalculateMovement()
	{
		Vector2 input = GetInput();
		if (input.x == 0 || input.y == 0)
			movement = new Vector2(speed.x*input.x, speed.y*input.y);
		else 
			movement = new Vector2(speed.x*input.x/Mathf.Sqrt(2), speed.y*input.y/Mathf.Sqrt(2));
	}
	
	// Move rigid body
	void Move()
	{
		rigidbody2D.velocity = movement;
	}
	
	void Update()
	{
		if (gameState.GetComponent<GameState>().currentState == GameStates.PLAYING)
		{
			CalculateMovement();
			endPos = transform.position;
		}
		else
		{
			transform.position = endPos;
			transform.rigidbody2D.velocity = new Vector2(0f,0f);
		}
	}
	
	void FixedUpdate()
	{
		Move();
	}
}