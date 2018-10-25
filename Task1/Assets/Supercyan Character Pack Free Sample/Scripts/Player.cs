using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


	public Animator m_animator;
//	public bool m_isJump, m_isRun, m_isIdl;
	public Transform GroundObject,GroundObject2;
	private Transform CubeTransform;

	public bool left;
	private Rigidbody CubeRigidBody;
	//	private GameObject enemyScript;
	public bool isGrounded;

	public int highCount;




	private Vector3 trgPost;


	// Use this for initialization


	//Healthbar..........



	public bool isDown, isRight, isUp;



	void Start ()
	{

		CubeRigidBody = GetComponent<Rigidbody> ();
		CubeTransform = GetComponent<Transform> ();

	}


	public bool Grounded;
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.y < -6f) {

		


		}	

	


//
		Grounded = Physics.Linecast (GroundObject2.position, GroundObject.position, 1<< LayerMask.NameToLayer ("Ground"));
//		Debug.DrawLine ( GroundObject.position,GroundObject2.position, Color.red);


		if (isDown || (Input.GetKey (KeyCode.LeftArrow))) {


			CubeTransform.Translate (Vector3.forward * 5f * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, 180, 0);
		} 
		if (isRight || (Input.GetKey (KeyCode.RightArrow))) {

						CubeTransform.Translate (Vector3.forward * 5f * Time.deltaTime);
			transform.rotation = Quaternion.Euler (0, 0, 0);
				
		} 

		if (isUp && Grounded || (Input.GetKeyDown (KeyCode.Space)) && Grounded) {
			CubeRigidBody.AddForce (new Vector3 (0, 6f, 0), ForceMode.Impulse);
//			m_animator.SetBool ("isJUMP", true);
			m_animator.SetTrigger ("isJUMP");

		}

		if (isRight || (Input.GetKey (KeyCode.RightArrow)) || isDown || (Input.GetKey (KeyCode.LeftArrow))) {

			m_animator.SetBool ("isRUN", true);
		} else  {


			m_animator.SetBool ("isRUN", false);
		}
	}

	public void OnPointerLeftDown ()
	{
		isDown = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerLeftUp ()
	{
		isDown = false;
	}


	public void OnPointerRightDown ()
	{
		isRight = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerRightUp ()
	{
		isRight = false;
	}

	public void OnPointerJumpDown ()
	{
		isUp = true;
		//this.downTime = Time.realtimeSinceStartup;
	}

	public void OnPointerJumptUp ()
	{
		isUp = false;
	}

	public void  OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Ground") {

			isGrounded = true;


		}






	}






		


		

}




