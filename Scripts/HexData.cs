using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexData
{
	static HexData instance;

	Dictionary<string,GameObject> dict = new Dictionary<string, GameObject> ();

	private HexData ()
	{
	}


	public static HexData GetInstance { 
		
		get { 
			if (instance == null)
				instance = new HexData ();
			return instance; 
		} 
	}


	public string GetKeyByGameObject (GameObject go)
	{
		var key = from e in dict
		          where e.Value == go
		          select e.Key;
		return key.FirstOrDefault ();
	}


	public GameObject GetGameObjectByKey (string key)
	{
		var go = from e in dict
		         where e.Key == key
		         select e.Value;
		return go.FirstOrDefault ();
	}


	public void Add (string key, GameObject value)
	{
		dict.Add (key, value);
	}


	public int GetHexCount ()
	{
		return dict.Count;
	}


	public void RemoveHex (string key)
	{
		if (dict.ContainsKey (key))
			dict.Remove (key);
	}

}
