﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Timers;

public class Move : MonoBehaviour {
	public bool isGround;
	public bool goingUp; // true going up, false going down
	public float jumpDelay = 1.5f; // stop fast double jumps [Osawa]: Com 1.5f ficou melhor pois com o valor anterior de 0.3 tava muito rápido e causava salto duplo
	public float inactiveTime; // if action time is less than this time, can't do action
	public float actionTime;
	public float rayDistance = 0.1f; // distance center to ground
	public float jumpSpeed = 3f; // [Osawa]: Torna o salto menos "rápido", ficou mais orgânico aqui PS.[Álvaro] 3 não vai a estratosfera
	public bool escalada;
	public bool busted;
	public bool jgPausado;

	public Vector3 newCenterRun;

	public GameObject txtPausar;

	public int jumpTrigger;
	public int isGroundedBool;
	public int goingUpBool;
	//public int backForward = 1;
	public bool axis;

	private Rigidbody rigidBody;
	private Animator animator;


	private System.Timers.Timer timer = new System.Timers.Timer(4000);

	void Awake () 
	{
		jumpTrigger = Animator.StringToHash("Jump");
		goingUpBool = Animator.StringToHash("GoingUp");
		isGroundedBool = Animator.StringToHash("IsGrounded");

	}

	// Use this for initialization
	void Start () 
	{
		rigidBody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
 		inactiveTime = Time.time;
		axis = true;
		//txtPausar.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			jgPausado = !jgPausado; //Inverte o valor do booleano
			txtPausar.SetActive (jgPausado);
			if (jgPausado) 
			{
				Debug.Log ("Pausou");
				Time.timeScale = 0;
			}
			else 
			{
				Debug.Log ("Resumiu");
				Time.timeScale = 1;
			}
		}

		if (!busted) {
			Jump ();
			if (axis) {
				if (Input.GetAxis ("Vertical") < 0) {
					transform.position += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime * 1.25f;
				} else {
					transform.position += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime * 2.5f;
				}
			} else {
				if (Input.GetAxis ("Vertical") > 0) {
					transform.position += Vector3.forward * Input.GetAxis ("Horizontal") * Time.deltaTime * 1.25f;
				} else {
					transform.position += Vector3.forward * Input.GetAxis ("Horizontal") * Time.deltaTime * 2.5f;
				}
			}
			if (Input.GetAxis ("Horizontal") > 0) {
				if (Input.GetAxis ("Vertical") < 0) {
					animator.SetInteger ("Crouched", 1);
				} else {
					animator.SetInteger ("Crouched", 0); //Retornar a andar ereto mesmo em movimento
				}
				animator.SetBool ("Walking", true);
					if (axis) {
						transform.rotation = Quaternion.Euler (0, 270, 0);
					} else {
						transform.rotation = Quaternion.Euler (0, 0, 0);
					}
			} else if (Input.GetAxis ("Horizontal") < 0) {
				if (Input.GetAxis ("Vertical") < 0) {
					animator.SetInteger ("Crouched", -1);
				} else {
					animator.SetInteger ("Crouched", 0);
				}
				animator.SetBool ("Walking", true);
					if (axis) {
						transform.rotation = Quaternion.Euler (0, 90, 0);
					} else {
						transform.rotation = Quaternion.Euler (0, 180, 0);
					}
			} else {
				if (Input.GetAxisRaw ("Vertical") < 0) {
					animator.SetInteger ("Crouched", 3);
				} else {
					animator.SetInteger ("Crouched", 0);
				}
				animator.SetBool ("Walking", false);
			}
			if (animator.GetBool ("Walking") && animator.GetBool ("OnGround")) {
				animator.speed = 5;
			} else {
				animator.speed = 1;
			}
		} else {
			animator.SetBool ("Walking", false);
		}
		if(this.transform.position.y < -1.5f){
			Application.LoadLevel ("GameOver");
		}
	}

	public void Jump () 
	{
		//rigidBody.AddForce(Vector3.down*jumpSpeed*15);
		if (Input.GetAxis ("Vertical") > 0f && escalada) {
			rigidBody.velocity = Vector3.up;
		}
		if (Input.GetAxis ("Vertical") > 0f && !escalada) {

			if (Time.time < inactiveTime) {
				return;
			} else if (isGround == false) {
				return;
			}
			inactiveTime = Time.time + jumpDelay;
			goingUp = true;
			isGround = false;
			rigidBody.velocity = Vector3.up * jumpSpeed;
		}
	}

	void FixedUpdate () 
	{
		// check if character is on ground
		if (Physics.Raycast (transform.position + (Vector3.up * rayDistance), Vector3.down, rayDistance * 2)) 
		{
			isGround = true;
		}
		else {
			isGround = false;
		}

		// check if character is going up or down
		if (rigidBody.velocity.y > 0) {
			goingUp = true;
		}
		else {
			goingUp = false;
		}
		animator.SetBool ("OnGround", isGround);
	}

	void OnTriggerEnter (Collider other){
		if(other.CompareTag("Escada")){
			escalada = true;
			animator.SetBool ("escalando", true);
			rigidBody.useGravity = false;
		}
	}

	void OnTriggerExit (Collider other){
		if(other.CompareTag("Escada")){
			escalada = false;
			animator.SetBool ("escalando", false);
			rigidBody.useGravity = true;
		}
	}
}
