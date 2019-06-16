using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public List<GameObject> hexList = new List<GameObject> ();

	public Text RemainsClick;
	public Text RemainsHex;
	public GameObject CanvasHexGroup;
	public GameObject CanvasText;
	public GameObject CanvasPlay;
	public GameObject CanvasGameOver;

	[Space (20)]
	[Header ("---------------------------------------------")]
	[Space (5)]
	[Range (1, 2)] public int Range = 1;
	[Range (15, 50)]public int MAX_CLICKS = 40;

	public string RemainsClickString = "Remains Click : ";
	public string RemainsHexString = "Remains Hex : ";


	HexManager hexManager;


	// Use this for initialization
	void Start ()
	{
		InitializeGame ();
	}


	public void OnStartClick ()
	{
		CanvasPlay.SetActive (false);
		CanvasText.SetActive (true);
		CanvasHexGroup.SetActive (true);
	}


	public void OnCloseGame ()
	{
		#if !UNITY_EDITOR
		Application.Quit ();
		#endif
		Debug.Log ("Quit");
	}


	public void OnHexClick (GameObject go)
	{
		IHex hex = HexFactory.GetHex (go, Range);
		hex.Execute (go);

		UpdateClickText (--MAX_CLICKS);
		UpdateHexText (HexManager.HexCount);

		if (HexManager.HexCount == 0 || MAX_CLICKS == 0)
			OnGameOver ();

	}


	void InitializeGame ()
	{
		EnableCanvasForPlayGame ();

		UpdateHexText (hexList.Count);
		UpdateClickText (MAX_CLICKS);
	
		CreateHexGrid ();
	}


	void EnableCanvasForPlayGame ()
	{
		CanvasPlay.SetActive (true);
		CanvasText.SetActive (false);
		CanvasHexGroup.SetActive (false);
		CanvasGameOver.SetActive (false);
	}


	void EnableCanvasForGameOver ()
	{
		CanvasPlay.SetActive (false);
		CanvasText.SetActive (false);
		CanvasHexGroup.SetActive (false);
		CanvasGameOver.SetActive (true);
	}


	void CreateHexGrid ()
	{
		HexManager.SetHexList (hexList);
		HexManager.InitializeHex ();
	}


	void OnGameOver ()
	{
		EnableCanvasForGameOver ();
	}


	void UpdateHexText (int count)
	{
		RemainsHex.text = RemainsHexString + count;
	}


	void UpdateClickText (int count)
	{
		RemainsClick.text = RemainsClickString + count;
	}


}


public class BlankHex : IHex
{
	public int Range{ get; set; }


	public void Execute (GameObject selectedGameObject)
	{

		List<GameObject> hexInRange = HexManager.GetRangeObjects (selectedGameObject, Range);

		if (HexManager.IsFilledHexInRange (selectedGameObject, Range)) {
			hexInRange.ForEach (el => GameUtility.SetHexColorGreen (el));
			GameUtility.DisableHexInteractable (selectedGameObject);
			GameUtility.SetHexColorRed (selectedGameObject);
			HexManager.RemoveHexFromList (selectedGameObject);
		} else {
			hexInRange.ForEach (el => {
				GameUtility.SetHexColorRed (el);
				GameUtility.DisableHexInteractable (el);
				HexManager.RemoveHexFromList (el);
			});
		}
				
	}
}


public  class FilledHex : IHex
{
	public int Range{ get; set; }

	public void Execute (GameObject selectedGameObject)
	{
		GameUtility.DisableHexInteractable (selectedGameObject);
		GameUtility.EnableInsideText (selectedGameObject);
		GameUtility.SetHexColorGreen (selectedGameObject);
		HexManager.RemoveHexFromList (selectedGameObject);
	}
}



public class HexFactory
{
	public static IHex GetHex (GameObject gameObject, int _Range)
	{
		IHex hex;
		if (GameUtility.IsHexBlack (gameObject)) {
			hex = new BlankHex (){ Range = _Range };
		} else
			hex = new FilledHex ();

		return hex;
	}
}




