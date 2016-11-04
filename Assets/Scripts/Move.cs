using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Timers;

public class Move : MonoBehaviour {
	public bool isGround;
	public bool goingUp; // true going up, false going down
	public float jumpDelay = 0.1f; // stop fast double jumps
	public float inactiveTime; // if action time is less than this time, can't do action
	public float actionTime;
	public float rayDistance = 0.1f; // distance center to ground
	public float jumpSpeed = 6f;

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
		transform.position += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime;
		if (Input.GetAxis ("Horizontal") > 0) {
			animator.SetBool("Walking",true);
			transform.rotation = new Quaternion (0, -90, 0, 90);
		} else if (Input.GetAxis ("Horizontal") < 0) {
			animator.SetBool("Walking",true);
			transform.rotation = new Quaternion (0, 90, 0, 90);
		} else{
			animator.SetBool("Walking",false);
		}
	}

	public void Jump () 
	{
		rigidBody.AddForce(Vector3.down*jumpSpeed*15);
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
			rigidBody.AddForce(Vector3.up*jumpSpeed*170);
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
