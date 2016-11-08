using UnityEngine;
using System.Collections;

public class Meshy : MonoBehaviour {

	public Component[] children;

	// Use this for initialization
	void Start () {
		children = GetComponentsInChildren<MeshRenderer>( );
		foreach (MeshRenderer child in children) {
			child.gameObject.AddComponent <MeshCollider>();
			child.gameObject.GetComponent<MeshCollider> ().sharedMesh = child.gameObject.GetComponent<MeshFilter>().sharedMesh;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
