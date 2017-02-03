using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Escolha3 : MonoBehaviour {
    public Button escolha5, escolha6;
    public int option3;

	void Start () {
	   // =========SETAR BOTOES==========//
		escolha5.onClick = new Button.ButtonClickedEvent();
		escolha5.onClick.AddListener(() => changeFase(5,"Scene23")); //cena do trem
        
        escolha6.onClick = new Button.ButtonClickedEvent();
		escolha6.onClick.AddListener(() => changeFase(6,"Scene21")); //cena do deserto
	}
	
	//===========VOIDS NORMAIS=========//
	private void changeFase(int option3, string nomeCena){
		Debug.Log("Opção escolhida"+option3);

		Menu.nextScene = nomeCena;
		if (option3 == 5) {
			SceneManager.LoadScene ("Documento 4");
		} else {
			SceneManager.LoadScene ("Documento 5");
		}
	}
}
