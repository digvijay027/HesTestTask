using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HexManager
{
	static HexManager instance;

	static List<GameObject> _hexList = new List<GameObject> ();


	private HexManager ()
	{
	}


	public static void SetHexList (List<GameObject> hexList)
	{
		_hexList.AddRange (hexList);
	}


	public static int HexCount {
		get{ return _hexList.Count; }
		private set{ }
	}

	public static void InitializeHex ()
	{
		RandomNumber randomNumber = new RandomNumber (1, _hexList.Count);

		for (int i = 0; i < _hexList.Count; i++) {

			GameObject go = _hexList.ElementAt (i);

			go.GetComponentInChildren<Text> ().text = "" + i;

			if (Random.Range (0, 8) < 5) {
				go.GetComponentInChildren<Text> ().text = randomNumber.GetRandomNumber ().ToString ();
			} else {
				go.GetComponentInChildren<Text> ().text = "";
			}

			go.GetComponentInChildren<Text> ().enabled = false;
		}
	}


	public static GameObject GetHexAt (int index)
	{
		return _hexList.ElementAtOrDefault (index);
	}


	public static List<GameObject> GetRangeObjects (GameObject _from, float range)
	{
		range = range + 0.5f;
		return _hexList.Where (el => Vector3.Distance (el.transform.position, _from.transform.position) <= range).ToList ();

	}


	public static bool IsFilledHexInRange (GameObject _from, float range)
	{
		range = range + 0.5f;
		int filledHexCount = _hexList.Where (el => Vector3.Distance (el.transform.position, _from.transform.position) <= range).Where (el => el.GetComponentInChildren<Text> ().text != "").ToList ().Count;
	
		return filledHexCount > 0;
	}


	public static void RemoveHexFromList (GameObject item)
	{
		_hexList.Remove (item);
	}


}
