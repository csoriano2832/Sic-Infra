using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D info)
	{
		if (info.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
	}

}
