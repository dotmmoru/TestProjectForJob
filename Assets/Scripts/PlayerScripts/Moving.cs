using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

[System.Serializable]

public class Values 
{
	public float min_x , max_x, min_z , max_z ;
}


public class Moving : MonoBehaviour {

	public float speed , rotate;
	public Rigidbody projectile;
	public int Score;

	public Values val;
	private float moveHorizontal;
	private float moveVertical;
	private Vector3 move, dir;
	private Rigidbody rgb;

	public GameObject shot;
	public Transform shotSpawn;

	void Start ()
	{
		rgb = GetComponent<Rigidbody>();

	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
		}

	}

	void FixedUpdate () {
	
		moveHorizontal  = Input.GetAxis("Horizontal");
		moveVertical  = Input.GetAxis("Vertical");

		move = new Vector3 (moveHorizontal , 0.0f , moveVertical);
		rgb.velocity = move*speed;

		rgb.position = new Vector3(
			Mathf.Clamp(rgb.position.x,val.min_x,val.max_x),
			0.0f,
			Mathf.Clamp(rgb.position.z,val.min_z,val.max_z)
			);

		dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		dir.Normalize();
		if (Mathf.Atan2(dir.z, -dir.x) * Mathf.Rad2Deg <0)
			rgb.rotation  = Quaternion.Euler(rgb.velocity.x*-rotate,Mathf.Atan2(dir.z, -dir.x) * Mathf.Rad2Deg ,0.0f);
		else 
			rgb.rotation  = Quaternion.Euler(rgb.velocity.x*rotate,Mathf.Atan2(dir.z, -dir.x) * Mathf.Rad2Deg ,0.0f);
	}
	void OnCollisionEnter(Collision collision) {
		
		if ((collision.gameObject.tag == "Enemy")||(collision.gameObject.tag == "EnemyBullet"))
		{
			Rigidbody instantiatedProjectile = Instantiate (projectile,gameObject.transform.position,gameObject.transform.rotation)as Rigidbody;
			SavePlayerPrefs();
			Destroy(this.gameObject);
			Application.LoadLevel(2);
		}
	}

	void SavePlayerPrefs ()
	{
		UILabel c = GameObject.Find("ScoreLabelValue").GetComponent<UILabel>();
	
		PlayerPrefs.SetString("Score",c.text);

	}
	
}







