/* 
 Authors-
	Chris
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{


	// Checks Update for Playstation controls
	public void Update()
	{
		// Playstation Options Override
		if (Application.platform == RuntimePlatform.PS4) 
		{
			if(Input.GetButtonDown("Submit"))
			{
				SceneManager.LoadScene(1);
			}
		}
			
	}

	// On Start Button Click
	public void StartButtonClicked()
	{
		// Load Game Scene
		SceneManager.LoadScene(1);
	}

	// On Quit Button Click
	public void QuitButtonClicked()
	{
		Application.Quit();
	}
}
