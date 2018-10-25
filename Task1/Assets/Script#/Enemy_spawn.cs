using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		for(int x=1;x<7;x++) {
			Instantiate (target,new Vector3(x * -19f,2.0f,0),Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
