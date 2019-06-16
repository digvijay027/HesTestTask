using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber
{
	List<int> numbers = new List<int> ();

	public RandomNumber (int start, int count)
	{
		for (int i = start; i <= start + count; i++) {
			numbers.Add (i);
		}
	}

	public int GetRandomNumber ()
	{
		int randNumber = -1;

		if (numbers.Count > 0) {
			int randPosition = Random.Range (0, numbers.Count);
			randNumber = numbers [randPosition];
			numbers.RemoveAt (randPosition);
		}
		return randNumber;
	}

}
