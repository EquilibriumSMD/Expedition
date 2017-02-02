using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			Application.LoadLevel ("Win");
		}
	}
}
