using UnityEngine;
using System.Collections;

public class Elysio : MonoBehaviour {


	/** Para acesso mais eficiente ao componente Animator
	 */
	private Animator animator;
	private Rigidbody rigidBody;
	private Collider collider;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		collider = GetComponent<Collider> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime;
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool("Walking",true);
		} else {
			animator.SetBool("Walking",false);
		}
	}
}
