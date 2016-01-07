using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {

	public float Speed;
	public Rigidbody projectile;
	private Transform target;
	public bool isRocket ;

	void Start () 
	{
		if (!isRocket)
		{
		GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,Speed));
		}
		else 
		{
			target = GameObject.FindWithTag ("Player").transform;
		}
	}

	void Update()
	{

		if (isRocket)
		{
			transform.LookAt (target.transform);
			transform.Translate (new Vector3 (0, 0, Speed * Time.deltaTime));
	
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		
		if ((collision.gameObject.tag == "Bullet")||(collision.gameObject.tag == "Player")||(collision.gameObject.tag == "EnemyBullet"))
		{
			Rigidbody instantiatedProjectile = Instantiate (projectile,gameObject.transform.position,gameObject.transform.rotation)as Rigidbody;
			
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider col) {

		if ((col.gameObject.tag == "Enemy"))
		GetComponent<CapsuleCollider>().enabled = false;


	}
	
	void OnTriggerExit(Collider col) {
		if ((col.gameObject.tag == "Enemy"))
		GetComponent<CapsuleCollider>().enabled = true;
	}
}
