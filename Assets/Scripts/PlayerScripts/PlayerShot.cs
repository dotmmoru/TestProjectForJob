using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {

	public float Speed;
	public Rigidbody projectile;
	void Start () 
	{
		GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0,0,Speed));
	}

	void OnCollisionEnter(Collision collision) {
		
		if ((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "EnemyBullet"))
		{

			if (collision.gameObject.tag == "Enemy")
			{
				UILabel c = GameObject.Find("ScoreLabelValue").GetComponent<UILabel>();
				c.text = (int.Parse(c.text) +1).ToString();

			}
			Rigidbody instantiatedProjectile = Instantiate (projectile,gameObject.transform.position,gameObject.transform.rotation)as Rigidbody;
			
			Destroy(gameObject);
		}
	}

}
