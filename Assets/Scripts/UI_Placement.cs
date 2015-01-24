using UnityEngine;
using System.Collections;

public class UI_Placement : MonoBehaviour 
{
	public Vector3 pos;
	
	//private float initialCameraSize;
	
	void Start () 
	{
		//initialCameraSize = Camera.main.orthographicSize;
	}
	
	void Update () 
	{
		Vector3 finalPosition = Camera.main.WorldToScreenPoint(pos);
		Vector3 screenPos = new Vector3(Screen.width,Screen.height,0f);
		finalPosition = screenPos - finalPosition;
		//float scale = Camera.main.orthographicSize/initialCameraSize;
		//transform.localScale = (new Vector2(scale,scale));
		gameObject.transform.position = Camera.main.ScreenToWorldPoint(finalPosition);
	}
}