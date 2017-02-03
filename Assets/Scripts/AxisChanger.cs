using UnityEngine;
using System.Collections;

public class AxisChanger : MonoBehaviour {

	//public bool changeBF = false;

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			other.GetComponent<Move> ().axis = !other.GetComponent<Move> ().axis ;
			/*if (changeBF) {
				other.GetComponent<Move> ().backForward = -1;
			} else{
				other.GetComponent<Move> ().backForward = 1;
			} */
		}
	}
}
