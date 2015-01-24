using UnityEngine;
using System.Collections;

public class LanternScript : MonoBehaviour 
{
	public GameObject player;

	public Vector3 front = new Vector3(-0.35f,2.2f,0f);
	public Vector3 front_left = new Vector3(-0.35f,2.2f,0f);
	public Vector3 left = new Vector3(-0.35f,2.2f,0f);
	public Vector3 back_left = new Vector3(-0.35f,2.2f,0f);
	public Vector3 back = new Vector3(-0.35f,2.2f,0f);
	public Vector3 back_right = new Vector3(-0.35f,2.2f,0f);
	public Vector3 right = new Vector3(-0.35f,2.2f,0f);
	public Vector3 front_right = new Vector3(-0.35f,2.2f,0f);

	void Update () 
	{
		transform.eulerAngles = player.transform.eulerAngles;

		Vector3 pos;

		if (transform.eulerAngles.z < 22.5 ) //0
			pos = front;
		else if (transform.eulerAngles.z < 77.5) //45
			pos = front_left;
		else if (transform.eulerAngles.z < 112.5) //90
			pos = left;
		else if (transform.eulerAngles.z < 157.5) //135
			pos = back_left;
		else if (transform.eulerAngles.z < 202.5) //180
			pos = back;
		else if (transform.eulerAngles.z < 247.5) //225
			pos = back_right;
		else if (transform.eulerAngles.z < 292.5) //270
			pos = right;
		else //if (transform.eulerAngles.z == 315)
			pos = front_right;

		transform.position = player.transform.position;// + pos;
	}
}
