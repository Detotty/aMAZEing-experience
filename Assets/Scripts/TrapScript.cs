using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour
{
	public enum TrapType
	{
		SingleActivation,
		ToggleActivation
	};

	public TrapType trapType = TrapType.SingleActivation;

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

	void Awake()
	{
		SetActiveChildren(false);
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (trapType == TrapType.SingleActivation)
			SetActiveChildren(true);
		else if (trapType == TrapType.ToggleActivation)
			ToggleActiveChildren();
	}
}
