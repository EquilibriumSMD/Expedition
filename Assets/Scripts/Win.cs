using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	public string escolha;

	void OnTriggerEnter(Collider other)
	{
		if((other.GetComponent<Collider>().CompareTag("Player")))
		{
			Application.LoadLevel (escolha);
		}
	}
}
