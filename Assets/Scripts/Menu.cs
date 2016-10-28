using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGui() {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 120, 60), "Play")) {
            Application.LoadLevel("Fase1");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height/2+80, 120, 60), "Extra")){
            Application.LoadLevel("Extra");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 160, 120, 60), "Opções")){
            Application.LoadLevel("Opcoes");
        }
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 240, 120, 60), "Créditos")){
            Application.LoadLevel("Creditos");
        }
    }
}
