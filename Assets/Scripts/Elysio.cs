using UnityEngine;
using System.Collections;

public class Elysio : MonoBehaviour {


	/** Para acesso mais eficiente ao componente Animator
	 */
	private Animator animator;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += Vector3.left * Input.GetAxis ("Horizontal") * Time.deltaTime;
		if (Input.GetAxis ("Vertical") > 0) {
			rigidBody.AddForce (Vector3.up * 20);
		}
	}
}
