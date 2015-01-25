using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour
{
	public enum TrapType
	{
		SingleActivation,
		ToggleActivation,
		CageActivation
	};

	public TrapType trapType = TrapType.SingleActivation;

	public float cageFirstDuration = 5;
	public float cageDuration = 10;

	// Variables used for timed traps
	private bool isTrapRunning = false;
	private float elapsedTime = 0;

	void SetActiveChildren(bool value)
	{
		foreach (Transform childTransform in gameObject.transform)
			childTransform.gameObject.SetActive(value);
	}

	void ToggleActiveChildren()
	{
		foreach (Transform childTransform in gameObject.transform)
		{
			if (childTransform.gameObject.activeSelf)
				childTransform.gameObject.SetActive(false);
			else
				childTransform.gameObject.SetActive(true);
		}
	}
	
	void CageActiveChildren()
	{
		isTrapRunning = true;

		foreach (Transform childTransform in gameObject.transform)
		{
			childTransform.gameObject.SetActive(true);
		}
	}

	void CageTrapFinish()
	{
		if (elapsedTime > cageFirstDuration && elapsedTime < cageDuration)
		{
			foreach (Transform childTransform in gameObject.transform)
			{
				if (childTransform.gameObject.CompareTag("CageTrapFirstWall"))
					childTransform.gameObject.SetActive(false);
			}
		}
		else if (elapsedTime > cageDuration)
		{
			foreach (Transform childTransform in gameObject.transform)
			{
				if (!childTransform.gameObject.CompareTag("CageTrapFirstWall"))
					childTransform.gameObject.SetActive(false);
			}

			isTrapRunning = false;
		}
	}

	void Awake()
	{
		SetActiveChildren(false);
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		elapsedTime = 0;

		if (trapType == TrapType.SingleActivation)
			SetActiveChildren(true);
		else if (trapType == TrapType.ToggleActivation)
			ToggleActiveChildren();
		else if (trapType == TrapType.CageActivation)
			CageActiveChildren();
	}

	void Update()
	{
		if (isTrapRunning)
		{
			elapsedTime += Time.deltaTime;

			if (trapType == TrapType.CageActivation)
				CageTrapFinish();
			else
				Debug.LogError("Trap running but no finish method. Type: " + trapType);
		}
	}
}
