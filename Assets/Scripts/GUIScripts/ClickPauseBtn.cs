using UnityEngine;
using System.Collections;

public class ClickPauseBtn : MonoBehaviour {

	void start ()
	{

		GameObject Menu  = GameObject.Find("MainMenu");
		NGUITools.SetActive(Menu,false);  
		GameObject Save  = GameObject.Find("Save");
		NGUITools.SetActive(Save,false);   
		GameObject Exit  = GameObject.Find("Exit");
		NGUITools.SetActive(Exit,false);   
	}


	void OnClickPause()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}else 
		{
			if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
			
			}
		}
	}

	void GoToMenu ()
	{
		Application.LoadLevel(0);

	}

	void ExitGame ()
	{
		Application.Quit();

	}

}
