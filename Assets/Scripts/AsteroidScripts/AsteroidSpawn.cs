using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	public GameObject Asteroid;
	public float x;
	Vector3 pos ;
	public float DelayTimerSpawn ;
	float Spawntimer;

	void Update () 
	{
		Spawntimer -= Time.deltaTime;
		if (Spawntimer <=0)
		{
			pos = new Vector3( Random.Range(-x, x), 0,28f);
			transform.position = pos;
			Instantiate (Asteroid,gameObject.transform.position,gameObject.transform.rotation);
			Spawntimer = DelayTimerSpawn;
		}


	}
}
