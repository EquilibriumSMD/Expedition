using UnityEngine;
using System.Collections;

public class AxisChanger : MonoBehaviour {

	//public bool axis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			//other.GetComponent<Move> ().axis = axis;
			other.GetComponent<Move> ().axis = !other.GetComponent<Move> ().axis ;
		}
	}
}
