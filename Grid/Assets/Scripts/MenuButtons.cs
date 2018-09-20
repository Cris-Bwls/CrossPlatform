using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{


	public void Update()
	{
		if (Application.platform == RuntimePlatform.PS4) 
		{
			if(Input.GetButtonDown("Submit"))
			{
				SceneManager.LoadScene(1);
			}
		}
			
	}

	public void StartButtonClicked()
	{
		SceneManager.LoadScene(1);
	}

	public void QuitButtonClicked()
	{
		Application.Quit();
	}
}
