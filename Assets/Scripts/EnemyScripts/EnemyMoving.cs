using UnityEngine;
using System.Collections;

public class EnemyMoving : MonoBehaviour {
	
	//дистанция до атаки
	public float attackDistance = 7.0f;
	//скорость енеми
	public float speed = 6;
	//игрок
	private Transform target;
	public Rigidbody projectile;

	public GameObject shot;
	public Transform RightshotSpawn;


	public float DelayTimerShot;
	float Shottimer;

	void Start ()
	{       
		target = GameObject.FindWithTag ("Player").transform;
	}

	void Update ()
	{
			if (Vector3.Distance (transform.position, target.transform.position) > attackDistance) 
            {

			Shottimer -= Time.deltaTime;
			if (Shottimer <=0)
			{

			Instantiate(shot,RightshotSpawn.position,RightshotSpawn.rotation);
			
			Shottimer = DelayTimerShot;
			}
				//walk
				transform.LookAt (target.transform);
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));

		}
	}

	void OnCollisionEnter(Collision collision) {
		
		if ((collision.gameObject.tag == "Player")||(collision.gameObject.tag == "Bullet"))
		{
			Rigidbody instantiatedProjectile = Instantiate (projectile,gameObject.transform.position,gameObject.transform.rotation)as Rigidbody;
			
			Destroy(gameObject);
		}
	}

}
