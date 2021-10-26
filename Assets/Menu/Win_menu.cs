using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_menu : MonoBehaviour
{
	public void PlayGame()
	{
		Global.death = 0;
		SceneManager.LoadScene("level01");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
