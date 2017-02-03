using UnityEngine;
using System.Collections;

public class Hacks : MonoBehaviour {

	public Component[] children;
	public Component[] hottdren;

	// Use this for initialization
	void Start () {
		children = GetComponentsInChildren<Transform>( );
		hottdren = GameObject.Find ("scene1_modificada").GetComponentsInChildren<Transform> ();

		foreach (Transform child in children) {
			foreach (Transform hottd in hottdren) {
				if (child.name == hottd.name) {
					child.transform.position = hottd.transform.position;
				}
			}			
		}
	}
}
