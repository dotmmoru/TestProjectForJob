using UnityEngine;
using System.Collections;

public class Control: MonoBehaviour {


	void exit () {
		Application.Quit();
	}
	void newGame () {
		Application.LoadLevel(1);
	}

}
