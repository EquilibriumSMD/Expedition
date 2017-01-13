using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class MoveMobile : MonoBehaviour 
{
	public float moveForce = 0.000005f;

	Rigidbody myBody;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		myBody = this.GetComponent<Rigidbody> ();
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 moveVec = new Vector3 (CrossPlatformInputManager.GetAxis ("Horizontal"), 0)*moveForce;
		Debug.Log (moveVec);
		//myBody.AddForce (moveVec);
		transform.position += -1*moveVec;

		if (Input.GetAxis ("Horizontal") > 0) {
			if (Input.GetAxis ("Vertical") < 0) {
				animator.SetInteger ("Crouched", 1);
			}
			else
			{
				animator.SetInteger("Crouched", 0); //Retornar a andar ereto mesmo em movimento
			}
			animator.SetBool("Walking",true);
			transform.rotation = new Quaternion (0, -90, 0, 90);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			if (Input.GetAxis ("Vertical") < 0) {
				animator.SetInteger ("Crouched", -1);
			}
			else
			{
				animator.SetInteger("Crouched", 0);
			}
			animator.SetBool("Walking",true);
			transform.rotation = new Quaternion (0, 90, 0, 90);
		} else{
			if (Input.GetAxisRaw ("Vertical") < 0) {
				animator.SetInteger ("Crouched", 3);
			} else {
				animator.SetInteger ("Crouched", 0);
			}
			animator.SetBool("Walking",false);
		}
		if (animator.GetBool ("Walking") && animator.GetBool("OnGround")) {
			animator.speed = 5;
		} else {
			animator.speed = 1;
		}
	}
}
