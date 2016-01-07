using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	public GameObject [] Enemy;
	public float x,z;
	Vector3 pos ;
	public float DelayTimerSpawn ;
	float Spawntimer;
	


	void Update () 
	{
		Spawntimer -= Time.deltaTime;
		if (Spawntimer <=0)
		{
			if (gameObject.tag == "VerticalSpawn")
			pos = new Vector3(x, 0, Random.Range(-z, z));
			if (gameObject.tag == "HorizontalSpawn")
				pos = new Vector3( Random.Range(-x, x), 0,z);
			transform.position = pos;
			Instantiate (Enemy[Random.Range(0, Enemy.Length)],gameObject.transform.position,gameObject.transform.rotation);
			Spawntimer = DelayTimerSpawn;
		}
		
	}




}
