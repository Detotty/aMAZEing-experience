using UnityEngine;
using System.Collections;

public class CharacterRotationScript : MonoBehaviour
{
	void Update () 
	{
		if (rigidbody2D.velocity != new Vector2(0,0))
		{
			ChangeDirection();
			//SwitchDirection();
		}
	}

	//HARDCODER
	void SwitchDirection()
	{
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 1)
			transform.eulerAngles = new Vector3(0f,0f,0f);
		if (Input.GetAxis("Horizontal") == -1 && Input.GetAxis("Vertical") == 1)
			transform.eulerAngles = new Vector3(0f,0f,45f);
		if (Input.GetAxis("Horizontal") == -1 && Input.GetAxis("Vertical") == 0)
			transform.eulerAngles = new Vector3(0f,0f,90f);
		if (Input.GetAxis("Horizontal") == -1 && Input.GetAxis("Vertical") == -1)
			transform.eulerAngles = new Vector3(0f,0f,135f);
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == -1)
			transform.eulerAngles = new Vector3(0f,0f,180f);
		if (Input.GetAxis("Horizontal") == 1 && Input.GetAxis("Vertical") == -1)
			transform.eulerAngles = new Vector3(0f,0f,225f);
		if (Input.GetAxis("Horizontal") == 1 && Input.GetAxis("Vertical") == 0)
			transform.eulerAngles = new Vector3(0f,0f,270f);
		if (Input.GetAxis("Horizontal") == 1 && Input.GetAxis("Vertical") == 1)
			transform.eulerAngles = new Vector3(0f,0f,315f);
	}
	
	void ChangeDirection()
	{
		float angle;

		angle = CalculateAngle() + 3*Mathf.PI/2;

		if (angle >= 2*Mathf.PI)
			angle = angle - 2*Mathf.PI;

		transform.eulerAngles = new Vector3(0f,0f,angle*180/Mathf.PI);
	}

	float CalculateAngle()
	{
		//If vel.y == 0 or x ==0, Atan is not going to return the right direction
		if (rigidbody2D.velocity.y == 0)
			return rigidbody2D.velocity.x > 0 ? 0 : Mathf.PI;
		else if (rigidbody2D.velocity.x == 0)
			return rigidbody2D.velocity.y > 0 ? Mathf.PI/2 : 3*Mathf.PI/2;
		else
			return Mathf.Atan2(rigidbody2D.velocity.y,rigidbody2D.velocity.x);
	}
}
