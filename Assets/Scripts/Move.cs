using UnityEngine;
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
	public float jumpSpeed = 5f; // [Osawa]: Torna o salto menos "rápido", ficou mais orgânico aqui

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
		Jump ();
		if (Input.GetAxis ("Vertical") < 0) {
			transform.position += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime * 2.5f;
		} else {
			transform.position += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime * 5f;
		}
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

	public void Jump () 
	{
		//rigidBody.AddForce(Vector3.down*jumpSpeed*15);
		if (Input.GetAxis ("Vertical") > 0f)
		{

			if (Time.time < inactiveTime) {
				return;
			}
			else if (isGround == false) {
				return;
			}
			inactiveTime = Time.time + jumpDelay;
			goingUp = true;
			isGround = false;
			rigidBody.velocity = Vector3.up*jumpSpeed;
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
}
