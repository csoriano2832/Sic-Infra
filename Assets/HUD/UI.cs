using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public PlayerMovement player;
	public Text livesText;
	public Text deathText;
	public Text coinsText;

	void start()
	{
		player = GetComponent<PlayerMovement>();
	}

	void Update()
	{
		livesText.text = "HEALTH : " + player.health;
		deathText.text = "DEATHS : " + Global.death;
		coinsText.text = player.coins.ToString();
	}
}
