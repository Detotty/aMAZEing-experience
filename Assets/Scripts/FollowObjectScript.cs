using UnityEngine;
using System.Collections;

public class FollowObjectScript : MonoBehaviour 
{
	public GameObject followed;

	public Vector3 pos;
	private Vector3 followedPos;

	void Start () 
	{
		UpdatePosition();
	}
	
	void Update () 
	{
		UpdatePosition();
	}

	void UpdatePosition()
	{
		followedPos = followed.transform.position;
		transform.position = followedPos + pos;
	}
}
