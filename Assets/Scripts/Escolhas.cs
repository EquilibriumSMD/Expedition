using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Escolhas : MonoBehaviour {

	public Button escolha1, escolha2, escolha3, escolha4, decisa5, escolha6;


	void Start () {

		// =========SETAR BOTOES==========//
		escolha1.onClick = new Button.ButtonClickedEvent();
		escolha1.onClick.AddListener(() => changeFase("Scene1")); //cena do trem -- leva para a segunda escolha
        
        escolha2.onClick = new Button.ButtonClickedEvent();
		escolha2.onClick.AddListener(() => changeFase("Scene2")); //cena do taj mahal -- leva para a terceira escolha
        
        escolha3.onClick = new Button.ButtonClickedEvent();
        escolha4.onClick = new Button.ButtonClickedEvent();
        
        escolha5.onClick = new Button.ButtonClickedEvent();
        escolha6.onClick = new Button.ButtonClickedEvent();
        
        
        //se tiver escolhido a primeira opção na primeira decisão
        if(escolha1 == true){
            escolha3.onClick.AddListener(() => changeFase("Scene1")); //cena do deserto -- próxima cena: taj mahal
            escolha4.onClick.AddListener(() => changeFase("Scene2")); //cena do taj mahal -- próxima cena: deserto
        }
        
        //se tiver escolhido a segunda opção na primeira decisão
        if(escolha2 == true){
            escolha5.onClick.AddListener(() => changeFase("Scene1")); //cena do trem -- próxima cena: deserto
            escolha6.onClick.AddListener(() => changeFase("Scene2")); //cena do deserto -- próxima cena:trem
        }
        
        //se tiver escolhido a primeira opção na primeira decisão
        if(escolha3 == true){
            changeFase("Scene2"); //cena: deserto
        }
        
        //se tiver escolhido a segunda opção na primeira decisão
        if(escolha4 == true){
            changeFase("Scene1"); //cena: taj mahal
        }
        
        //se tiver escolhido a primeira opção na primeira decisão
        if(escolha5 == true){
            changeFase("Scene2"); //cena: trem
        }
        
        //se tiver escolhido a segunda opção na primeira decisão
        if(escolha6 == true){
            changeFase("Scene1"); //cena: deserto
        }
	}

	//===========VOIDS NORMAIS=========//
	private void changeFase(string nomeCena){
		SceneManager.LoadScene (nomeCena);
	}
}
