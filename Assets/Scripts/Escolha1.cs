using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Escolha1 : MonoBehaviour {

	public Button escolha1, escolha2;
    public int option;

	void Start () {

		// =========SETAR BOTOES==========//
		escolha1.onClick = new Button.ButtonClickedEvent();
		escolha1.onClick.AddListener(() => changeFase(1,"Scene3")); //cena do trem
        
        escolha2.onClick = new Button.ButtonClickedEvent();
		escolha2.onClick.AddListener(() => changeFase(2,"Scene2")); //cena do taj mahal
        
    }
    
	//===========VOIDS NORMAIS=========//
	private void changeFase(int option, string nomeCena){
        Debug.Log("Opção escolhida"+option);

		Menu.nextScene = nomeCena;
		SceneManager.LoadScene ("Loading");
	}
}
