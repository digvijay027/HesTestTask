using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHex
{
	int Range{ get; set; }

	void Execute (GameObject selectedGameObject);
}

