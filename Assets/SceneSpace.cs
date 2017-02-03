using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSpace : MonoBehaviour {

	public string scene = "Loading";
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			SceneManager.LoadScene (scene);
		}
	}
}
