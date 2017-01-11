using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {


	/** Para acesso mais eficiente ao componente Animator
	 */
	private Animator animator;
	private Rigidbody rigidBody;
	private Collider collider;
	public Vector3 startPosition;
	public float radius;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		collider = GetComponent<Collider> ();
		rigidBody = GetComponent<Rigidbody> ();
		startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = startPosition + Vector3.left *  Mathf.Sin(Time.time) * radius * Time.deltaTime;
	}
}
