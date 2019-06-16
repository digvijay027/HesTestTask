using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameUtility
{
	private GameUtility ()
	{
	}

	public static void EnableInsideText (GameObject gameObject)
	{
		gameObject.GetComponentInChildren<Text> ().enabled = true;
	}

	public static void DisableHexInteractable (GameObject gameObject)
	{
		gameObject.GetComponentInChildren<EventTrigger> ().enabled = false;
	}

	public static void SetHexColorRed (GameObject gameObject)
	{
		gameObject.GetComponentInChildren<MeshRenderer> ().material.color = Color.red;
	}

	public static void SetHexColorGreen (GameObject gameObject)
	{
		gameObject.GetComponentInChildren<MeshRenderer> ().material.color = Color.green;
	}

	public static bool IsHexBlack (GameObject gameObject)
	{
		return gameObject.GetComponentInChildren<Text> ().text == "";
	}
}

