using UnityEngine;
using System.Collections;

public class ShowScore : MonoBehaviour {

	public string LoadedScore;

	// Use this for initialization
	void Start () {
		LoadPlayerPrefs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadPlayerPrefs()
	{
		if (PlayerPrefs.HasKey("Score"))
		{
		UILabel c = GameObject.Find("ScoreLabel").GetComponent<UILabel>();
		c.text = PlayerPrefs.GetString("Score");
		}
	}
}
