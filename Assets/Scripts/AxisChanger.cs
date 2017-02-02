using UnityEngine;
using System.Collections;

public class AxisChanger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			other.GetComponent<Move> ().axis = !other.GetComponent<Move> ().axis ;
		}
	}
}
