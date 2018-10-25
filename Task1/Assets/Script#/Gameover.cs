using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour {
	public Transform CubeTransform;
	public Rigidbody CubeRigidbody;
	public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

//		if(Input.GetKey(KeyCode.Mouse0)) {
//		
//
//
//		}
	}
	public void right() {
		CubeTransform.Translate (Vector3.forward * 5f  * Time.deltaTime);
		transform.rotation = Quaternion.Euler (0,90,0);
		anim.SetBool ("Player_move", true);

	}
	public void left() {

		CubeTransform.Translate (Vector3.forward * 5f  * Time.deltaTime);
		transform.rotation = Quaternion.Euler (0,-90,0);
		anim.SetBool ("Player_move", true);

	}
	public void jump() {
		
		CubeRigidbody.AddForce (new Vector3 (0, 1.8f, 0), ForceMode.Impulse);


	}
	public void buttonClick() {

		Application.LoadLevel (Application.loadedLevel);
		Debug.Log ("Debuggin");

	}
}
