using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Timers;

public class Inimigo : MonoBehaviour {
	public bool isGround;
	public bool goingUp; // true going up, false going down
	public float jumpDelay = 1.5f; // stop fast double jumps [Osawa]: Com 1.5f ficou melhor pois com o valor anterior de 0.3 tava muito rápido e causava salto duplo
	public float inactiveTime; // if action time is less than this time, can't do action
	public float actionTime;
	public float rayDistance = 0.1f; // distance center to ground
	public float jumpSpeed = 5f; // [Osawa]: Torna o salto menos "rápido", ficou mais orgânico aqui
	public float radius = 0.5f; // "Raio" da distância percorrida

	public Vector3 arrest = new Vector3();
	public Vector3 newCenterRun;

	public int jumpTrigger;
	public int isGroundedBool;
	public int goingUpBool;

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
	}

	// Update is called once per frame
	void Update () 
	{
		if (arrest == new Vector3()) {
			if (Mathf.Cos (Time.time) < 0) {
				transform.position += Vector3.left * Mathf.Cos (Time.time) * radius * Time.deltaTime * 5f;
			} else {
				transform.position += Vector3.left * Mathf.Cos (Time.time) * radius * Time.deltaTime * 5f;
			}
			if (Mathf.Cos (Time.time) > 0) {
				animator.SetBool ("Walking", true);
				transform.rotation = new Quaternion (0, -90, 0, 90);
			} else if (Mathf.Cos (Time.time) < 0) {
				animator.SetBool ("Walking", true);
				transform.rotation = new Quaternion (0, 90, 0, 90);
			} else {
				animator.SetBool ("Walking", false);
			}
			if (animator.GetBool ("Walking") && animator.GetBool ("OnGround")) {
				animator.speed = 5;
			} else {
				animator.speed = 1;
			}
		} else {
			transform.position = Vector3.MoveTowards(transform.position, arrest, Time.deltaTime);
			if(Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(arrest.x, 0, arrest.z)) < 0.3f){
				Application.LoadLevel ("GameOver");
			}
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

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")) && arrest == new Vector3())
		{
			other.GetComponent<Move> ().busted = true;
			arrest = other.GetComponent<Transform> ().position;
		}
	}
}
