using UnityEngine;
using System.Collections;

public class Elysio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate (Vector3.forward/100);
	}
}
