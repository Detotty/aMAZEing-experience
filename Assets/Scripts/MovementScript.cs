using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
	// Movement variables
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(1, 0);
	private Vector2 movement;
	
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
		movement = new Vector2(speed.x*input.x, speed.y*input.y);
	}
	
	// Move rigid body
	void Move()
	{
		rigidbody2D.velocity = movement;
	}
	
	void Update()
	{
		CalculateMovement();
	}
	
	void FixedUpdate()
	{
		Move();
	}
}