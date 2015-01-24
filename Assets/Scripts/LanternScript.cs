using UnityEngine;
using System.Collections;

public class LanternScript : MonoBehaviour 
{
	public GameObject player;

	void Update () 
	{
		transform.eulerAngles = player.transform.eulerAngles;
		transform.position = player.transform.position;
	}
}
