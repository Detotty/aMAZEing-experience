using UnityEngine;
using System.Collections;

public class BatteriesScript : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			BatteriesHelper.Instance.IncreasePower();
			Destroy(gameObject);
		}
	}
}
