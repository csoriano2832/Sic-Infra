using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
	public static float death = 0;

	public void IncreaseDeaths()
	{
		death++;
	}

}
