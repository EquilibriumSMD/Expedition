using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Escolha2 : MonoBehaviour {
    public Button escolha3, escolha4;
    public int option2;

	void Start () {
	   // =========SETAR BOTOES==========//
		escolha3.onClick = new Button.ButtonClickedEvent();
		escolha3.onClick.AddListener(() => changeFase(3,"Scene31")); //cena do deserto
        
        escolha4.onClick = new Button.ButtonClickedEvent();
		escolha4.onClick.AddListener(() => changeFase(4,"Scene32")); //cena do taj mahal
	}
	
	//===========VOIDS NORMAIS=========//
	private void changeFase(int option2, string nomeCena){
		Debug.Log("Opção escolhida"+option2);

		Menu.nextScene = nomeCena;
		SceneManager.LoadScene ("Loading");
	}
}
