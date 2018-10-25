using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawn : MonoBehaviour {
	public static Bullet_Spawn instanceBullet;
	public GameObject target;
	// Use this for initialization
	void Start () 
	{
		instanceBullet = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			fire ();
		}

	}

	public void fire() 
	{
		//Debug.Log (transform.forward);
		GameObject targetSpawn = Instantiate (target,transform.position,target.transform.rotation) as GameObject;
		Rigidbody  rb = targetSpawn.GetComponent<Rigidbody>();
		Debug.Log ("AAAAAAAAAAAAAAA"+targetSpawn.transform.forward);
		rb.AddForce (rb.transform.up * 150f);
		Destroy (target.gameObject,2f);

	}
}
