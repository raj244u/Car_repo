using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject targetSpawn = Instantiate (transform.position,target.transform.rotation) as GameObject;
		Rigidbody  rb = GetComponent<Rigidbody>();
		//Debug.Log ("AAAAAAAAAAAAAAA"+targetSpawn.transform.forward);
		rb.AddForce (rb.transform.forward * 50f);
		Destroy (this.gameObject,2f);
	}
}
