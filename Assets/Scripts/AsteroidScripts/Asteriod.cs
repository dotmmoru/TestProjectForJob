using UnityEngine;
using System.Collections;

public class Asteriod : MonoBehaviour {

	public Rigidbody projectile;
	public float rot; 
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rot;
		GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(Random.Range(-10,10),0,Random.Range(-10,10)));
	}


	void OnCollisionEnter(Collision collision) {
		
		if ((collision.gameObject.tag == "Bullet")||(collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "Player"))
		{
			Rigidbody instantiatedProjectile = Instantiate (projectile,gameObject.transform.position,gameObject.transform.rotation)as Rigidbody;
			
			Destroy(gameObject);
		}
	}
}
