using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
		for(int x=1;x<10;x++) {
			Instantiate (target,new Vector3(x * -18f,5f,0),Quaternion.identity);



		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
