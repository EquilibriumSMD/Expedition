using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject protagonista;
	public float diffX, diffY, diffZ;

	// Use this for initialization
	void Start () {
		diffX = 0f;
		diffY = 2f;
		diffZ = 8f;
	}

	void Reset() {
		diffX = 0f;
		diffY = 2f;
		diffZ = 8f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.Slerp (this.transform.position, new Vector3 (protagonista.transform.position.x + diffX, protagonista.transform.position.y + diffY, protagonista.transform.position.z + diffZ), Time.deltaTime);
	}
}
