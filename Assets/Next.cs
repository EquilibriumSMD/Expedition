using UnityEngine;
using System.Collections;

public class Next : MonoBehaviour {

	public string next;

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			Menu.nextScene = next;
			Application.LoadLevel ("Loading");
		}
	}
}
