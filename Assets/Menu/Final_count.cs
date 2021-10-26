using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_count : MonoBehaviour
{

	public Text deaths;

	void Update()
	{
		if (Global.death == 0)
		{
			deaths.text = "DEATHS : " + Global.death + " \nWelcome Home, Ashen One";
		}
		else if (Global.death < 10)
		{
			deaths.text = "DEATHS : " + Global.death + " \nDon't give up, skeleton";
		}
		else if (Global.death >= 10)
		{
			deaths.text = "DEATHS : " + Global.death + " \nDon't you dare go hollow";
		}

	}
}
